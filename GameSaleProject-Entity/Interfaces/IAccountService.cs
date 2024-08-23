using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.ViewModels;
using Microsoft.AspNetCore.Http;

namespace GameSaleProject_Entity.Interfaces
{
    public interface IAccountService 
    {
        Task<string> CreateUserAsync(RegisterViewModel model);
        Task<bool> AssignRoleToUserAsync(string userId, string roleName);
        Task<string> FindByNameAsync(LoginViewModel model);
        Task<UserViewModel> FindByUserNameAsync(string name);
        Task<UserViewModel> FindByIdAsync(int userId);
        Task<string> CreateRoleAsync(RoleViewModel model);
        Task<List<UserViewModel>> GetAllUsers();
        Task<List<RoleViewModel>> GetAllRoles();
        Task<string> SaveProfilePictureAsync(IFormFile formFile);
        Task SignOutAsync();
    }
}
