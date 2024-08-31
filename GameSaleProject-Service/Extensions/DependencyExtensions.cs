using GameSaleProject_DataAccess.Contexts;
using GameSaleProject_DataAccess.UnitOfWorks;
using GameSaleProject_Entity.Identity;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.UnitOfWorks;
using GameSaleProject_Service.Initialization;
using GameSaleProject_Service.Mapping;
using GameSaleProject_Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GameSaleProject_Service.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddExtensions(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(
                 opt =>
                 {
                    opt.Password.RequiredLength = 6;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequireUppercase = true;
                    opt.Password.RequireLowercase = true;
                    opt.Password.RequireDigit = true;

                    opt.User.RequireUniqueEmail = true;
                    opt.User.AllowedUserNameCharacters = "zxcvbnmasdfghjklqwertyuiop1234567890";
                    opt.Lockout.MaxFailedAccessAttempts = 3;
                    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);

                 }
            ).AddEntityFrameworkStores<GameSaleProjectDbContext>();

            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGameSaleService, GameSaleService>();
            services.AddScoped<IGameSaleDetailService, GameSaleDetailService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ISystemRequirementService, SystemRequirementService>();
            services.AddScoped<IUserProfileService, UserProfileService>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<RoleInitializer>();

        }
    }
}
