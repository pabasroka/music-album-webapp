using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using music_album_webapp.Entities;
using music_album_webapp.Exceptions;
using music_album_webapp.Models;

namespace music_album_webapp.Services;

public interface IAlbumService
{
    Pagination<AlbumDto> GetAll(AlbumQuery query);
    IEnumerable<TrackDto> GetTracksByAlbumId(int id);
}

public class AlbumService : IAlbumService
{
    private readonly DataContext _dataContext;
    private readonly IUserContextService _userContextService;
    private readonly IMapper _mapper;

    public AlbumService(DataContext dataContext, IUserContextService userContextService, IMapper mapper)
    {
        _dataContext = dataContext;
        _userContextService = userContextService;
        _mapper = mapper;
    }
    
    public Pagination<AlbumDto> GetAll(AlbumQuery query)
    {
        var distributionId = _userContextService.GetUserDistributionId;

        var queryBuilder = _dataContext
            .Albums
            .Include(t => t.Tracks)
            .Include(d => d.Distribution)
            .Where(a => a.DistributionId == distributionId)
            .Where(a => query.SearchPhrase == null || a.Author.ToLower().Contains(query.SearchPhrase.ToLower())
                                                   || a.Title.ToLower().Contains(query.SearchPhrase.ToLower())
                                                   || a.Id.ToString().Contains(query.SearchPhrase))
            .Where(a => query.ReleaseYear == null || query.ReleaseYear == a.ReleaseYear);

        if (queryBuilder is null)
        {
            throw new NotFoundException("Album not found");
        }

        if (!string.IsNullOrEmpty(query.SortBy))
        {
            var columnsSelectors = new Dictionary<string, Expression<Func<Album, object>>>
            {
                {nameof(Album.ReleaseYear), a => a.ReleaseYear},
                {nameof(Album.Author), a => a.Author},
                {nameof(Album.Title), a => a.Title},
            };

            var selectedColumn = columnsSelectors[query.SortBy];

            queryBuilder = query.SortDirection == SortDirection.Asc
                ? queryBuilder.OrderBy(selectedColumn)
                : queryBuilder.OrderByDescending(selectedColumn);
        }

        var albums = queryBuilder
            .Skip(query.PaginationSize * (query.CurrentPage - 1))
            .Take(query.PaginationSize)
            .ToList();

        var albumsDtos = _mapper.Map<List<AlbumDto>>(albums);

        var results = new Pagination<AlbumDto>(albumsDtos, queryBuilder.Count(), query.CurrentPage, query.PaginationSize);
        
        return results;
    }
    
    public IEnumerable<TrackDto> GetTracksByAlbumId(int id)
    {
        var distributionId = _userContextService.GetUserDistributionId;
        
        var tracks = _dataContext
            .Albums
            .Where(a => a.DistributionId == distributionId)
            .Where(a => a.Id == id)
            .SelectMany(a => a.Tracks)
            .ToList();
        
        if (tracks is null)
        {
            throw new NotFoundException("Tracks not found");
        }

        var result = _mapper.Map<IEnumerable<TrackDto>>(tracks);
        return result;
    }
}