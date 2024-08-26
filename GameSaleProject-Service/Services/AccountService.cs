using AutoMapper;
using GameSaleProject_DataAccess.Contexts;
using GameSaleProject_Entity.Identity;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameSaleProject_Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly GameSaleProjectDbContext _context;
        public AccountService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper, GameSaleProjectDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _context = context;
        }


        public async Task<string> CreateRoleAsync(RoleViewModel model)
        {
            string message = string.Empty;
            var roleExists = await _roleManager.RoleExistsAsync(model.Name);
            if (!roleExists)
            {
                var role = new AppRole()
                {
                    Name = model.Name,
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
        public async Task<bool> AssignRoleToUserAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded;
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
                UserName = model.UserName,
                ProfilePictureUrl = model.ProfilePictureUrl // Assuming this is included in RegisterViewModel
            };

            var identityResult = await _userManager.CreateAsync(user, model.Password);

            if (identityResult.Succeeded)
            {
                // Assign the default role, e.g., "User"
                var roleResult = await _userManager.AddToRoleAsync(user, "User");

                if (roleResult.Succeeded)
                {
                    message = "OK";
                }
                else
                {
                    // If assigning the role fails, delete the user to avoid having a user without a role
                    await _userManager.DeleteAsync(user);
                    message = string.Join(", ", roleResult.Errors.Select(e => e.Description));
                }
            }
            else
            {
                message = string.Join(", ", identityResult.Errors.Select(e => e.Description));
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
        public async Task<UserViewModel> FindByIdAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            return _mapper.Map<UserViewModel>(user);
        }
        public async Task<List<RoleViewModel>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var roleViewModels = _mapper.Map<List<RoleViewModel>>(roles);
            return roleViewModels;
        }

        public async Task<List<UserViewModel>> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var userViewModels = _mapper.Map<List<UserViewModel>>(users);
            return userViewModels;
        }



        public async Task<string> SaveProfilePictureAsync(IFormFile formFile)
        {
            var fileName = Path.GetFileNameWithoutExtension(formFile.FileName);
            var extension = Path.GetExtension(formFile.FileName);
            var newFileName = $"{fileName}_{DateTime.Now.Ticks}{extension}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newFileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            return "/images/" + newFileName;
        }
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
