using GameSaleProject_Entity.Identity;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using GameSaleProject_Service.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Areas.User.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IAccountService _accountService;

        public UserProfileController(IUserProfileService userProfileService, IAccountService accountService)
        {
            _userProfileService = userProfileService;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userName = User.Identity.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Login", "Account");
            }

            var user = await _accountService.FindByUserNameAsync(userName);

            if (user == null)
            {
                return NotFound("User not found");
            }

            return View(user); // Pass the UserViewModel to the view
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UserViewModel model)
        {
            var userName = User.Identity.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Login", "Account");
            }

            // Get the user information using the existing method
            var user = await _accountService.FindByUserNameAsync(userName);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var userId = user.Id; // Retrieve the user ID from the UserViewModel

            if (ModelState.IsValid)
            {
                var success = await _userProfileService.UpdateUserProfileAsync(userId, model);
                if (success)
                {
                    TempData["Message"] = "Profile updated successfully.";
                    return RedirectToAction("Profile");
                }
                ModelState.AddModelError("", "Failed to update profile. Please try again.");
            }

            return View(model);
        }
    }
}
