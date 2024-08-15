using GameSaleProject_DataAccess.Contexts;
using GameSaleProject_Service.Extensions;
using GameSaleProject_Service.Initialization;
using Microsoft.EntityFrameworkCore;
namespace GameSaleProject_Mvc
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<GameSaleProjectDbContext>(
             options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")
              ));

            builder.Services.AddExtensions();
            var app = builder.Build();

            // Role initialization
            using (var scope = app.Services.CreateScope())
            {
                var roleInitializer = scope.ServiceProvider.GetRequiredService<RoleInitializer>();
                await roleInitializer.InitializeAsync();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
            name: "area",
            pattern: "{controller=Home}/{action=Index}/{area=Admin}"
          );
            app.Run();
        }
    }
}
