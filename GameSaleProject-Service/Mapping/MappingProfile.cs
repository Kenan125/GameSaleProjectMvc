using AutoMapper;
using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Identity;
using GameSaleProject_Entity.ViewModels;

namespace GameSaleProject_Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameViewModel>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews))
                .ReverseMap();
            CreateMap<AppUser, UserViewModel>().ReverseMap();


            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Image, ImageViewModel>().ReverseMap();
            CreateMap<Publisher, PublisherViewModel>()
            .ForMember(dest => dest.Games, opt => opt.MapFrom(src => src.Games))
            .ReverseMap();
            CreateMap<GameSale, GameSaleViewModel>().ReverseMap();
            CreateMap<GameSaleDetail, GameSaleDetailViewModel>().ReverseMap();
            CreateMap<AppRole, RoleViewModel>().ReverseMap();
            CreateMap<Review, ReviewViewModel>().ReverseMap();
            CreateMap<SystemRequirement, SystemRequirementViewModel>().ReverseMap();


        }
    }
}
