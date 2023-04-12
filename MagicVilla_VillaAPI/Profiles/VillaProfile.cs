using AutoMapper;
using MagicVilla_Data.Entities;
using MagicVilla_VillaAPI.Models.ViewModels;

namespace MagicVilla_VillaAPI.Profiles
{
    public class VillaProfile : Profile
    {
        public VillaProfile()
        {
            CreateMap<Villa, VillaDTO>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id)
                 )
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name)
                )
                .ForMember(
                    dest => dest.Details,
                    opt => opt.MapFrom(src => src.Details)
                )
                .ForMember(
                    dest => dest.Rate,
                    opt => opt.MapFrom(src => src.Rate)
                )
                .ForMember(
                    dest => dest.Sqft,
                    opt => opt.MapFrom(src => src.Sqft)
                )
                .ForMember(
                    dest => dest.Occupancy,
                    opt => opt.MapFrom(src => src.Occupancy)
                ).ForMember(
                    dest => dest.ImageUrl,
                    opt => opt.MapFrom(src => src.ImageUrl)
                ).ForMember(
                    dest => dest.Amenity,
                    opt => opt.MapFrom(src => src.Amenity)
                )
                .ReverseMap();
        }
    }
}
