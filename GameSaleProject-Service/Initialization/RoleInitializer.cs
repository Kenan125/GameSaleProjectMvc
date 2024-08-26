using GameSaleProject_Entity.Identity;
using Microsoft.AspNetCore.Identity;

namespace GameSaleProject_Service.Initialization
{
    public class RoleInitializer
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleInitializer(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task InitializeAsync()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                var role = new AppRole { Name = "Admin", Description = "Administrator role" };
                await _roleManager.CreateAsync(role);
            }

            if (!await _roleManager.RoleExistsAsync("User"))
            {
                var role = new AppRole { Name = "User", Description = "Regular user role" };
                await _roleManager.CreateAsync(role);
            }
            if (!await _roleManager.RoleExistsAsync("Publisher"))
            {
                var role = new AppRole { Name = "Publisher", Description = "Role for publishers" };
                await _roleManager.CreateAsync(role);
            }
        }
    }
}
