using AutoMapper;
using SkinHunt.Application.Common.Entities;
using SkinHunt.Application.Common.Models;

namespace SkinHunt.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SkinModel, SkinEntity>()
                .ReverseMap();

            CreateMap<ItemTypeModel, ItemTypeEntity>()
                .ReverseMap();

            CreateMap<BasketModel, BasketEntity>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Skin, opt => opt.MapFrom(src => src.SkinId))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.Data));
        }
    }
}
