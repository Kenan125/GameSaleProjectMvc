using AutoMapper;
using GameSaleProject_Entity.Identity;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Areas.User.Controllers
{
    [Area("User")]
    public class UserProfileController : Controller
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IAccountService _accountService;
        private readonly IGameSaleService _gameSaleService;
        private readonly IMapper _mapper;
        private readonly IPublisherService _publisherService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public UserProfileController(
            IUserProfileService userProfileService,
            IAccountService accountService,
            IGameSaleService gameSaleService,
            IMapper mapper,
            IPublisherService publisherService,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager)
        {
            _userProfileService = userProfileService;
            _accountService = accountService;
            _gameSaleService = gameSaleService;
            _mapper = mapper;
            _publisherService = publisherService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        private async Task<UserViewModel?> GetAuthenticatedUserAsync()
        {
            var userName = User.Identity.Name;
            if (string.IsNullOrEmpty(userName))
            {
                return null;
            }
            return await _accountService.FindByUserNameAsync(userName);
        }

        private void SetActivePage(string pageName)
        {
            ViewBag.ActivePage = pageName;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SetActivePage("UserDetails");
            var user = await GetAuthenticatedUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> OwnedGames()
        {
            SetActivePage("OwnedGames");
            var user = await GetAuthenticatedUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var userPurchases = await _gameSaleService.GetUserPurchasesAsync(user.UserName);
            var ownedGames = userPurchases
                .SelectMany(purchase => purchase.GameSaleDetails)
                .Where(detail => detail.Game != null)
                .Select(detail => _mapper.Map<GameViewModel>(detail.Game))
                .ToList();

            return View(ownedGames);
        }

        [HttpGet]
        public async Task<IActionResult> PurchaseHistory()
        {
            SetActivePage("PurchaseHistory");
            var user = await GetAuthenticatedUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var userPurchases = await _gameSaleService.GetUserPurchasesAsync(user.UserName);
            if (!userPurchases.Any())
            {
                ViewBag.Message = "You have not made any purchases yet.";
                return View(new List<GameSaleViewModel>());
            }
            return View(userPurchases);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var username = User.Identity.Name; 
            var userId = await _userProfileService.FindUserIdByUserNameAsync(username);

            if (userId == null)
            {
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction("Login", "Account");
            }

            var userProfile = await _userProfileService.GetUserProfileAsync(userId.Value);

            if (userProfile == null)
            {
                TempData["ErrorMessage"] = "User profile not found.";
                return RedirectToAction("EditProfile");
            }

            return View(userProfile);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(UserViewModel model, IFormFile? profilePicture)
        {
            
            if (model == null)
            {
                TempData["ErrorMessage"] = "Invalid user data.";
                return RedirectToAction("EditProfile");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var username = User.Identity.Name; 
            var userId = await _userProfileService.FindUserIdByUserNameAsync(username);

            if (userId == null)
            {
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction("Login", "Account");
            }
           
            if (profilePicture != null && profilePicture.Length > 0)
            {
                var profilePictureUrl = await _accountService.SaveProfilePictureAsync(profilePicture);
                model.ProfilePictureUrl = profilePictureUrl;
            }
            var updateSucceeded = await _userProfileService.UpdateUserProfileAsync(userId.Value, model);

            if (updateSucceeded)
            {
                TempData["SuccessMessage"] = "Profile updated successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update profile. Please check your details.";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> BecomePublisher()
        {
            SetActivePage("BecomePublisher");
            var user = await GetAuthenticatedUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BecomePublisher(PublisherViewModel model)
        {
            var user = await GetAuthenticatedUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ModelState.Remove("User");
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _publisherService.CreatePublisherAsync(model, user.Id);
            if (!result)
            {
                ModelState.AddModelError("", "Failed to register as a publisher. Please try again.");
                return View(model);
            }

            await _accountService.AssignRoleToUserAsync(user.Id.ToString(), "Publisher");
            var appUser = await _userManager.FindByIdAsync(user.Id.ToString());
            if (appUser == null)
            {
                return RedirectToAction("Login", "Account");
            }
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(appUser, isPersistent: false);

            return RedirectToAction("Index", new { Message = "You have successfully registered as a publisher." });
        }
    }
}
