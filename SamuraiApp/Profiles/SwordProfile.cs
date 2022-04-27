using AutoMapper;
using Domain.Models;
using SamuraiApp.DTO.Samurai;
using SamuraiApp.DTO.Sword;

namespace SamuraiApp.Profiles
{
    public class SwordProfile : Profile
    {
        public SwordProfile()
        {
            CreateMap<Sword, ViewSwordDTO>();
            CreateMap<CreateSwordDTO, Sword>();
            CreateMap<CreateSwordSamuraiDTO, Sword>();
            CreateMap<CreateSwordWithElementDTO, Sword>();
            CreateMap<Sword, ViewSwordWithElementDTO>();
            CreateMap<CreateSwordElementSamuraiDTO, Sword>();
        }
    }
}
