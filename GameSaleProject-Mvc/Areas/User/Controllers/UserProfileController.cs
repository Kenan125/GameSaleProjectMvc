using AutoMapper;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
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
        private readonly IWebHostEnvironment _environment;
        private readonly IPublisherService _publisherService;

        public UserProfileController(IUserProfileService userProfileService, IAccountService accountService, IGameSaleService gameSaleService, IMapper mapper, IWebHostEnvironment environment, IPublisherService publisherService)
        {
            _userProfileService = userProfileService;
            _accountService = accountService;
            _gameSaleService = gameSaleService;
            _mapper = mapper;
            _environment = environment;
            _publisherService = publisherService;
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

            // Directly return the list of GameSaleViewModel for the view to consume
            return View(userPurchases);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            SetActivePage("EditProfile");

            var user = await GetAuthenticatedUserAsync();

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserViewModel model, IFormFile ProfilePicture)
        {
            ModelState.Remove("ProfilePicture");
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await GetAuthenticatedUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Check if the new password matches the confirmation
            if (!string.IsNullOrEmpty(model.NewPassword) && model.NewPassword != model.ConfirmNewPassword)
            {
                ModelState.AddModelError("ConfirmNewPassword", "The new password and confirmation password do not match.");
                return View(model);
            }

            // Upload the profile picture if provided
            if (ProfilePicture != null && ProfilePicture.Length > 0)
            {
                model.ProfilePictureUrl = await UploadImageAsync(ProfilePicture, "ProfilePicture");
            }

            var result = await _userProfileService.UpdateUserProfileAsync(user.Id, model);

            if (result)
            {
                return RedirectToAction("Index", new { Message = "Profile updated successfully." });
            }

            ModelState.AddModelError("", "Failed to update profile. Please check the input and try again.");
            return View(model);
        }
        private async Task<string> UploadImageAsync(IFormFile imageFile, string imageType)
        {
            var fileName = $"{Path.GetFileNameWithoutExtension(imageFile.FileName)}_{DateTime.Now.Ticks}{Path.GetExtension(imageFile.FileName)}";
            var filePath = Path.Combine(_environment.WebRootPath, "images", fileName);

            if (!Directory.Exists(Path.Combine(_environment.WebRootPath, "images")))
            {
                Directory.CreateDirectory(Path.Combine(_environment.WebRootPath, "images"));
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return $"/images/{fileName}";
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

            // Render the view for becoming a publisher
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BecomePublisher(PublisherViewModel model)
        {
            // Ensure the user is authenticated
            var user = await GetAuthenticatedUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Set the UserId in the model
            //model.UserId = user.Id;
            ModelState.Remove("User");
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Delegate the registration of the publisher to the PublisherService
            var result = await _publisherService.CreatePublisherAsync(model, user.Id);
            if (!result)
            {
                ModelState.AddModelError("", "Failed to register as a publisher. Please try again.");
                return View(model);
            }

            // Change the user's role to "Publisher"
            await _accountService.AssignRoleToUserAsync(user.Id.ToString(), "Publisher");

            return RedirectToAction("Index", new { Message = "You have successfully registered as a publisher." });
        }





    }
}
