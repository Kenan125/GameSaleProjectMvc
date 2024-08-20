using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IAccountService _accountService;

        public CartController(ICartService cartService, IAccountService accountService)
        {
            _cartService = cartService;
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
        // Implement this method to get the current user's ID
        
    }
}
