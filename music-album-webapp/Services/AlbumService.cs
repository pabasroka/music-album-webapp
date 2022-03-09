using AutoMapper;
using Microsoft.EntityFrameworkCore;
using music_album_webapp.Entities;
using music_album_webapp.Exceptions;
using music_album_webapp.Models;

namespace music_album_webapp.Services;

public interface IAlbumService
{
    IEnumerable<AlbumDto> GetAll(AlbumQuery query);
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
    
    public IEnumerable<AlbumDto> GetAll(AlbumQuery query)
    {
        var distributionId = _userContextService.GetUserDistributionId;

        var albums = _dataContext
            .Albums
            .Include(t => t.Tracks)
            .Include(d => d.Distribution)
            .Where(a => a.DistributionId == distributionId)
            .ToList();

        if (albums is null)
        {
            throw new NotFoundException("Album not found");
        }

        var results = _mapper.Map<List<AlbumDto>>(albums);
        return results;
    }
}