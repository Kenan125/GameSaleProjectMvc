using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IAccountService _accountService;
        private readonly IGameSaleService _gameSaleService;
        private readonly IGameService _gameService;

        public CartController(ICartService cartService, IAccountService accountService, IGameSaleService gameSaleService, IGameService gameService)
        {
            _cartService = cartService;
            _accountService = accountService;
            _gameSaleService = gameSaleService;
            _gameService = gameService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userName = User.Identity.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Login", "Account");
            }

            var cartViewModel = await _cartService.GetCartViewModelAsync(userName);

            return View(cartViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int gameId, decimal price)
        {
            var userName = User.Identity.Name;

            if (string.IsNullOrEmpty(userName))
            {
                // Handle the case where the user is not authenticated
                return RedirectToAction("Login", "Account");
            }

            // Optional: If you need additional user details, you can get the user from the account service
            var user = await _accountService.FindByUserNameAsync(userName);

            await _cartService.AddToCartAsync(userName, gameId, price);

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var userName = User.Identity.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Login", "Account");
            }

            var cart = await _cartService.GetCartAsync(userName);
            if (cart == null || !cart.Items.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            var userPurchases = await _gameSaleService.GetUserPurchasesAsync(userName);
            var alreadyPurchasedGames = cart.Items.Where(item =>
                userPurchases.Any(purchase => purchase.GameSaleDetails.Any(detail => detail.GameId == item.GameId))).ToList();

            if (alreadyPurchasedGames.Any())
            {
                // Handle the case where some games in the cart have already been purchased
                // You could remove these games from the cart, show a message, or prevent checkout entirely
                return RedirectToAction("Index", "Cart"); // Optionally, show an error message
            }

            var user = await _accountService.FindByUserNameAsync(userName);

            var gameSale = new GameSale
            {
                UserId = user.Id,
                TotalPrice = cart.Items.Sum(item => item.Price),
                TotalQuantity = cart.Items.Count,
                IsDiscountApplied = cart.Items.Any(item => item.Price < _gameService.GetGameByIdAsync(item.GameId).Result.Price), // Check if any item has a discount
                GameSaleDetails = cart.Items.Select(item => new GameSaleDetail
                {
                    GameId = item.GameId,
                    UnitPrice = item.Price,
                    IsRefunded = false // Assuming all games are refundable; this could be dynamic
                }).ToList()
            };

            await _gameSaleService.CreateGameSaleAsync(gameSale);
            await _cartService.ClearCartAsync(userName);

            return RedirectToAction("OrderConfirmation", new { gameSaleId = gameSale.Id });
        }

        public IActionResult OrderConfirmation(int gameSaleId)
        {
            // Display order confirmation with details from the sale
            var sale = _gameSaleService.GetGameSaleById(gameSaleId);
            return View(sale);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int gameId)
        {
            var userName = User.Identity.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("Login", "Account");
            }

            await _cartService.RemoveFromCartAsync(userName, gameId);

            return RedirectToAction("Index");
        }
    }
}
