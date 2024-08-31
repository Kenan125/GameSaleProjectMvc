using GameSaleProject_Entity.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IAccountService _accountService;
        public UserController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _accountService.GetAllUsers();
            var roles = await _accountService.GetAllRoles();
            ViewBag.Roles = roles;
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserRole(string userId, string roleName)
        {
            var result = await _accountService.AssignRoleToUserAsync(userId, roleName);
            if (result)
            {
                TempData["SuccessMessage"] = "Role updated successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error updating role.";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveUserRole(string userId, string roleName)
        {
            int userIdInt = int.Parse(userId); // Convert string to int
            var user = await _accountService.FindByIdAsync(userIdInt);
            if (user != null)
            {
                var result = await _accountService.RemoveRoleFromUserAsync(userId, roleName);
                if (result)
                {
                    TempData["SuccessMessage"] = "Role removed successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Error removing role.";
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> AddUserRole(string userId, string roleName)
        {
            var result = await _accountService.AssignRoleToUserAsync(userId, roleName);
            if (result)
            {
                TempData["SuccessMessage"] = "Role added successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error adding role.";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _accountService.DeleteUserAndRelatedDataAsync(userId);
            TempData["SuccessMessage"] = "User deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
