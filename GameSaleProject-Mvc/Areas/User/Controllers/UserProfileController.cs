using AutoMapper;
using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Identity;
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

        public UserProfileController(IUserProfileService userProfileService, IAccountService accountService, IGameSaleService gameSaleService, IMapper mapper)
        {
            _userProfileService = userProfileService;
            _accountService = accountService;
            _gameSaleService = gameSaleService;
            _mapper = mapper;
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
    }
}
