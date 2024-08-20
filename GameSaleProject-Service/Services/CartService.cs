using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using GameSaleProject_Service.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Service.Services
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGameService _gameService;
        public CartService(IHttpContextAccessor httpContextAccessor, IGameService gameService)
        {
            _httpContextAccessor = httpContextAccessor;
            _gameService = gameService;
        }

        public async Task AddToCartAsync(string userName, int gameId, decimal price)
        {
            var cart = await GetCartAsync(userName);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserName = userName,
                    GameId = gameId,
                    Price = price
                };
                await SaveCartAsync(cart);
            }
            // No need to update the cart since it's a digital game, and only one copy can be purchased.
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
            var cart = await GetCartAsync(userName);

            if (cart == null)
            {
                return new CartViewModel { UserName = userName, Items = new List<CartItemViewModel>() };
            }

            var cartViewModel = new CartViewModel
            {
                UserName = cart.UserName,
                Items = new List<CartItemViewModel>()
            };

            var game = await _gameService.GetGameByIdAsync(cart.GameId);
            if (game != null) // Check if the game exists
            {
                cartViewModel.Items.Add(new CartItemViewModel
                {
                    GameId = game.Id,
                    GameName = game.GameName,
                    Price = cart.Price
                });
            }

            return cartViewModel;
        }
    }
}
