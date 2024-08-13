using AutoMapper;
using GameSaleProject_DataAccess.Identity;
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
            CreateMap<AppUser, UserViewModel>()
    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
    .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.ProfilePictureUrl))
    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
    .ReverseMap();
            CreateMap<User, UserViewModel>()
    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
    .ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.ProfilePictureUrl))
    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
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
