using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
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
                
                return RedirectToAction("Login", "Account");
            }

            
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

            var totalPrice = cart.Items.Sum(item => item.Price);

            if (totalPrice > 0)
            {
                return RedirectToAction("Payment", new { totalPrice });
            }

            var gameSale = await _cartService.CheckoutAsync(userName);

            if (gameSale == null)
            {
                return RedirectToAction("Index", "Cart");
            }

            return RedirectToAction("OrderConfirmation", new { gameSaleId = gameSale.Id });
        }


        public async Task<IActionResult> OrderConfirmation(int gameSaleId)
        {
            
            var sale = await _gameSaleService.GetGameSaleByIdAsync(gameSaleId);
            return View(sale);
        }
        [HttpGet]
        public IActionResult Payment(decimal totalPrice)
        {
            var paymentViewModel = new PaymentViewModel
            {
                Amount = totalPrice
            };

            return View(paymentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Payment(PaymentViewModel model)
        {
            if (ModelState.IsValid)
            {               
                var userName = User.Identity.Name;
                var gameSale = await _cartService.CheckoutAsync(userName);

                if (gameSale == null)
                {
                    return RedirectToAction("Index", "Cart");
                }

                return RedirectToAction("OrderConfirmation", new { gameSaleId = gameSale.Id });
            }           
            return View(model);
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
