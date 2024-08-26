using Microsoft.Extensions.DependencyInjection;

namespace GameSaleProject_Service.Extensions
{
    public static class CookieConfigurationExtensions
    {
        public static IServiceCollection ConfigureCustomCookies(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(14);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            return services;
        }
    }
}
