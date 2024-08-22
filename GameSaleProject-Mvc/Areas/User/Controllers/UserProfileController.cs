using GameSaleProject_Entity.Entities;
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

        public UserProfileController(IUserProfileService userProfileService, IAccountService accountService, IGameSaleService gameSaleService)
        {
            _userProfileService = userProfileService;
            _accountService = accountService;
            _gameSaleService = gameSaleService;
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
        [HttpGet]
        public async Task<IActionResult> OwnedGames()
        {
            var userName = User.Identity.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Login", "Account");
            }

            // Get the user's purchases
            var userPurchases = await _gameSaleService.GetUserPurchasesAsync(userName);

            // Log the count of purchases and details for debugging
            var totalGames = userPurchases.SelectMany(purchase => purchase.GameSaleDetails).Count();
            Console.WriteLine($"User '{userName}' has {userPurchases.Count} purchases with a total of {totalGames} games.");

            var ownedGames = userPurchases
                .SelectMany(purchase => purchase.GameSaleDetails)
                .Select(detail => detail.Game)
                .Where(game => game != null)
                .ToList();

            Console.WriteLine($"Owned Games Count: {ownedGames.Count}");

            return View(ownedGames ?? new List<Game>());
        }

        [HttpGet]
        public async Task<IActionResult> PurchaseHistory()
        {
            var userName = User.Identity.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Login", "Account");
            }

            var userPurchases = await _gameSaleService.GetUserPurchasesAsync(userName);

            if (userPurchases == null || !userPurchases.Any())
            {
                ViewBag.Message = "You have not made any purchases yet.";
                return View(new List<PurchaseHistoryViewModel>());
            }

            var purchaseHistory = userPurchases.Select(purchase => new PurchaseHistoryViewModel
            {
                OrderId = purchase.Id,
                PurchaseDate = purchase.CreatedDate,
                TotalAmount = purchase.TotalPrice,
                PurchasedGames = purchase.GameSaleDetails?
        .Where(detail => detail.Game != null)
        .Select(detail => new PurchasedGameViewModel
        {
            GameName = detail.Game?.GameName,
            Price = detail.UnitPrice,
            Discount = detail.Discount, // Use the discount from GameSaleDetail
            CoverImageUrl = detail.Game?.Images?.FirstOrDefault()?.ImageUrl
        }).ToList() ?? new List<PurchasedGameViewModel>()
            }).ToList();

            return View(purchaseHistory);
        }

    }
}
