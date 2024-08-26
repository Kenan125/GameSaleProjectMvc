using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IAccountService _accountService;
        private readonly IGameSaleService _gameSaleService;
        private readonly IGameService _gameService;
        private string UserName => User.Identity.Name;
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
            var cartViewModel = await _cartService.GetCartViewModelAsync(UserName);
            return View(cartViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int gameId, decimal price)
        {
            await _cartService.AddToCartAsync(UserName, gameId, price);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var cart = await _cartService.GetCartAsync(UserName);
            if (cart == null || !cart.Items.Any())
            {
                return RedirectToAction("Index", "Cart");
            }

            var totalPrice = cart.Items.Sum(item => item.Price);

            if (totalPrice > 0)
            {
                return RedirectToAction("Payment", new { totalPrice });
            }

            var gameSale = await _cartService.CheckoutAsync(UserName);
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
                var gameSale = await _cartService.CheckoutAsync(UserName);
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
            await _cartService.RemoveFromCartAsync(UserName, gameId);
            return RedirectToAction("Index");
        }
    }
}
