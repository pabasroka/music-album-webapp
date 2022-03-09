using AutoMapper;
using music_album_webapp.Entities;
using music_album_webapp.Models;

namespace music_album_webapp;

public class DataMappingProfile : Profile
{
    public DataMappingProfile()
    {
        CreateMap<Album, AlbumDto>()
            .ForMember(m => m.DistributionName, c => c.MapFrom(s => s.Distribution.Name));
        
        CreateMap<Track, TrackDto>();
    }
}