using AutoMapper;
using Castles.Application.DTO.DatabaseDto;
using Castles.Entities;

namespace Castles.Application.Mappings;

public class CastleMappingProfile : Profile
{
    public CastleMappingProfile()
    {
        CreateMap<Castle, CastleDatabaseDto>()
            .ForMember(dest => dest.UpdateDate, opt => opt.Ignore())
            .ForMember(dest => dest.CreationDate, opt => opt.Ignore())
            .ForMember(dest => dest.Owner, opt => opt.Ignore())
            .ForMember(dest => dest.ViewingStatus, opt => opt.Ignore())
            .ForMember(dest => dest.Pictures, opt => opt.Ignore())
            .ReverseMap();
        
        CreateMap<CastleDetails, CastleDatabaseDto>()
            .ForMember(dest => dest.UpdateDate, opt => opt.Ignore())
            .ForMember(dest => dest.CreationDate, opt => opt.Ignore())
            .ForMember(dest => dest.Pictures, opt => opt.MapFrom(src => src.PicturePath))
            .ReverseMap();
        
        CreateMap<Owner, OwnerDatabaseDto>()
            .ForMember(dest => dest.Castles, opt => opt.Ignore())
            .ReverseMap();
        
        CreateMap<ViewingStatus, ViewingStatusDatabaseDto>()
            .ForMember(dest => dest.Castles, opt => opt.Ignore())
            .ReverseMap();
        
    }
}