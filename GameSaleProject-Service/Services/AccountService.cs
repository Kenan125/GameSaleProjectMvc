using AutoMapper;
using GameSaleProject_DataAccess.Identity;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        public AccountService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }


        public async Task<string> CreateRoleAsync(RoleViewModel model)
        {
            string message = string.Empty;
            var roleExists = await _roleManager.RoleExistsAsync(model.RoleName);
            if (!roleExists)
            {
                var role = new AppRole()
                {
                    Name = model.RoleName,
                    Description = model.Description // Assuming AppRole has a Description property
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    message = "Role created successfully.";
                }
                else
                {
                    message = string.Join(", ", result.Errors.Select(e => e.Description));
                }
            }
            else
            {
                message = "Role already exists.";
            }
            return message;
        }

        public async Task<string> CreateUserAsync(RegisterViewModel model)
        {
            string message = string.Empty;
            AppUser user = new AppUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                UserName = model.UserName
            };
            var identityResult = await _userManager.CreateAsync(user, model.Password);

            if (identityResult.Succeeded)
            {
                message = "OK";
            }
            else
            {
                foreach (var error in identityResult.Errors)
                {
                    message = error.Description;
                }
            }
            return message;
        }

        public async Task<string> FindByNameAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return "Kullanıcı bulunamadı!";
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            if (signInResult.Succeeded)
            {
                return "OK";
            }
            return "Giriş başarısız!";
        }

        public async Task<UserViewModel> FindByUserNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<List<RoleViewModel>> GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            var roleViewModels = _mapper.Map<List<RoleViewModel>>(roles);
            return roleViewModels;
        }

        public async Task<List<UserViewModel>> GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            var userViewModels = _mapper.Map<List<UserViewModel>>(users);
            return userViewModels;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

    }
}
