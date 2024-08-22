using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.Interfaces
{
    public interface ICartService
    {
        Task AddToCartAsync(string userName, int gameId, decimal price);
        Task<Cart> GetCartAsync(string userName);
        Task<CartViewModel> GetCartViewModelAsync(string userName);
        Task ClearCartAsync(string userName);
        Task RemoveFromCartAsync(string userName, int gameId);
    }
}
