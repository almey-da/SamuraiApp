﻿using AutoMapper;
using Domain.Models;
using SamuraiApp.DTO.Sword;

namespace SamuraiApp.Profiles
{
    public class SamuraiProfile : Profile
    {
        public SamuraiProfile()
            {
            CreateMap<Samurai, ViewSamuraiDTO>();
            CreateMap<CreateSamuraiDTO, Samurai>();
             }
    }
}