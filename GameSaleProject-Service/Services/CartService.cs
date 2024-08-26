using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using GameSaleProject_Service.Extensions;
using Microsoft.AspNetCore.Http;

namespace GameSaleProject_Service.Services
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGameService _gameService;
        private readonly IGameSaleService _gameSaleService;
        private readonly IAccountService _accountService;
        public CartService(IHttpContextAccessor httpContextAccessor, IGameService gameService, IGameSaleService gameSaleService, IAccountService accountService)
        {
            _httpContextAccessor = httpContextAccessor;
            _gameService = gameService;
            _gameSaleService = gameSaleService;
            _accountService = accountService;
        }

        public async Task AddToCartAsync(string userName, int gameId, decimal price)
        {

            var userPurchases = await _gameSaleService.GetUserPurchasesAsync(userName);
            if (userPurchases.Any(purchase => purchase.GameSaleDetails.Any(detail => detail.GameId == gameId)))
            {

                return;
            }

            var cart = await GetCartAsync(userName) ?? new Cart { UserName = userName };
            var existingItem = cart.Items.FirstOrDefault(item => item.GameId == gameId);
            if (existingItem == null)
            {

                cart.Items.Add(new CartItem
                {
                    GameId = gameId,
                    Price = price
                });
            }
            else
            {

                existingItem.Price = price;
            }

            await SaveCartAsync(cart);
        }
        public async Task<Cart> GetCartAsync(string userName)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            return await Task.FromResult(session.GetObjectFromJson<Cart>($"Cart_{userName}"));
        }
        public async Task ClearCartAsync(string userName)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            await Task.Run(() => session.Remove($"Cart_{userName}"));
        }

        private async Task SaveCartAsync(Cart cart)
        {
            var session = _httpContextAccessor.HttpContext.Session;
            await Task.Run(() => session.SetObjectAsJson($"Cart_{cart.UserName}", cart));
        }

        public async Task<CartViewModel> GetCartViewModelAsync(string userName)
        {
            var cart = await GetCartAsync(userName) ?? new Cart { UserName = userName };

            var cartViewModel = new CartViewModel
            {
                UserName = cart.UserName,
                Items = new List<CartItemViewModel>()
            };

            foreach (var cartItem in cart.Items)
            {
                var game = await _gameService.GetGameByIdAsync(cartItem.GameId);
                if (game != null)
                {
                    var discountedPrice = game.Price * (1 - (decimal)game.Discount / 100);
                    cartViewModel.Items.Add(new CartItemViewModel
                    {
                        GameId = game.Id,
                        GameName = game.GameName,
                        Price = discountedPrice
                    });
                    cartItem.Price = discountedPrice;
                }
            }
            await SaveCartAsync(cart);
            return cartViewModel;
        }

        public async Task<GameSale?> CheckoutAsync(string userName)
        {
            var cart = await GetCartAsync(userName);
            if (cart == null || !cart.Items.Any())
            {
                return null;
            }

            var userPurchases = await _gameSaleService.GetUserPurchasesAsync(userName);
            var alreadyPurchasedGames = new List<CartItem>();

            foreach (var item in cart.Items)
            {
                var isPurchased = userPurchases.Any(purchase =>
                    purchase.GameSaleDetails.Any(detail => detail.GameId == item.GameId));

                if (isPurchased)
                {
                    alreadyPurchasedGames.Add(item);
                }
            }

            if (alreadyPurchasedGames.Any())
            {
                return null; // Indicate that checkout cannot proceed due to already purchased games
            }

            var user = await _accountService.FindByUserNameAsync(userName);

            var gameSaleDetails = new List<GameSaleDetail>();
            bool isDiscountApplied = false;

            foreach (var item in cart.Items)
            {
                var game = await _gameService.GetGameByIdAsync(item.GameId);
                var detail = new GameSaleDetail
                {
                    GameId = item.GameId,
                    UnitPrice = item.Price,
                    Discount = game.Discount,
                    IsRefunded = false
                };

                gameSaleDetails.Add(detail);

                if (detail.UnitPrice < game.Price)
                {
                    isDiscountApplied = true;
                }
            }

            var gameSale = new GameSale
            {
                UserId = user.Id,
                TotalPrice = cart.Items.Sum(item => item.Price),
                TotalQuantity = cart.Items.Count,
                IsDiscountApplied = isDiscountApplied,
                GameSaleDetails = gameSaleDetails
            };

            await _gameSaleService.CreateGameSaleAsync(gameSale);
            await ClearCartAsync(userName);

            return gameSale;
        }



        public async Task RemoveFromCartAsync(string userName, int gameId)
        {
            var cart = await GetCartAsync(userName);

            if (cart != null)
            {
                var itemToRemove = cart.Items.FirstOrDefault(i => i.GameId == gameId);
                if (itemToRemove != null)
                {
                    cart.Items.Remove(itemToRemove);
                    await SaveCartAsync(cart);
                }
            }
        }
    }
}
