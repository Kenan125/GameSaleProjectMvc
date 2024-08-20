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
            var cart = await GetCartAsync(userName) ?? new Cart { UserName = userName };

            var existingItem = cart.Items.FirstOrDefault(item => item.GameId == gameId);
            if (existingItem == null)
            {
                // Add new game to the cart
                cart.Items.Add(new CartItem
                {
                    GameId = gameId,
                    Price = price
                });
            }
            else
            {
                // Optionally update the existing item's price or other details
                existingItem.Price = price; // This is optional and depends on your business logic
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
                    cartViewModel.Items.Add(new CartItemViewModel
                    {
                        GameId = game.Id,
                        GameName = game.GameName,
                        Price = cartItem.Price
                    });
                }
            }

            return cartViewModel;
        }
    }
}
