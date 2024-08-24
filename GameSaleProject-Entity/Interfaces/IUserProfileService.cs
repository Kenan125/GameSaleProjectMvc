using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Identity;
using GameSaleProject_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.Interfaces
{
    public interface IUserProfileService
    {
        Task<List<GameViewModel>> GetOwnedGamesAsync(int userId);
        Task<List<GameSale>> GetPurchaseHistoryAsync(int userId);
        Task<AppUser> GetUserProfileAsync(int userId);
        Task<bool> RefundGameAsync(int userId, int gameId);
        Task<bool> UpdateUserProfileAsync(int userId, UserViewModel model);
    }
}
