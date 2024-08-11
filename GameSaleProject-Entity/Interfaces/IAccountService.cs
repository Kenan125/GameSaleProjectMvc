using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.ViewModels;

namespace GameSaleProject_Entity.Interfaces
{
    public interface IAccountService 
    {
        Task<string> CreateUserAsync(RegisterViewModel model);
        Task<string> FindByNameAsync(LoginViewModel model);
        Task<UserViewModel> FindByUserNameAsync(string name);
        Task<string> CreateRoleAsync(RoleViewModel model);
        Task<List<UserViewModel>> GetAllUsers();
        Task<List<RoleViewModel>> GetAllRoles();

        Task SignOutAsync();
    }
}
