using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.ViewModels;

namespace GameSaleProject_Entity.Interfaces
{
    public interface ICartService
    {
        Task AddToCartAsync(string userName, int gameId, decimal price);
        Task<Cart> GetCartAsync(string userName);
        Task<CartViewModel> GetCartViewModelAsync(string userName);
        Task ClearCartAsync(string userName);
        Task<GameSale?> CheckoutAsync(string userName);
        Task RemoveFromCartAsync(string userName, int gameId);
    }
}
