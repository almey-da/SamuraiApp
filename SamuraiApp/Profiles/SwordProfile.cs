using AutoMapper;
using Domain.Models;
using SamuraiApp.DTO.Sword;

namespace SamuraiApp.Profiles
{
    public class SwordProfile : Profile
    {
        public SwordProfile()
        {
            CreateMap<Sword, ViewSwordDTO>();
            CreateMap<CreateSwordDTO, Sword>();
        }
    }
}
