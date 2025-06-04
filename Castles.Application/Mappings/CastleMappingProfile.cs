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
            .ReverseMap();
    }
}