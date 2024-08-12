﻿using AutoMapper;
using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameViewModel>()                
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src=> src.Images))
                .ForMember(dest=>dest.Reviews,opt=>opt.MapFrom(src=> src.Reviews))
                .ReverseMap();



            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Image, ImageViewModel>().ReverseMap();
            CreateMap<Publisher, PublisherViewModel>().ReverseMap();
            CreateMap<GameSale, GameSaleViewModel>().ReverseMap();
            CreateMap<GameSale, GameSaleDetailViewModel>().ReverseMap();
            CreateMap<Review, ReviewViewModel>().ReverseMap();
            CreateMap<SystemRequirement, SystemRequirementViewModel>().ReverseMap();
            

        }
    }
}