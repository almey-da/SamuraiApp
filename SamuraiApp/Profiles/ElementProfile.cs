using AutoMapper;
using Domain.Models;
using SamuraiApp.DTO.Element;

namespace SamuraiApp.Profiles
{
    public class ElementProfile:Profile
    {
        public ElementProfile()
        {
            CreateMap<Element, ViewElementDTO>();
            CreateMap<CreateElementDTO, Element>();
        }
    }
}
