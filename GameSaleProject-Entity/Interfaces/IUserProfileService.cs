using GameSaleProject_Entity.ViewModels;

namespace GameSaleProject_Entity.Interfaces
{
    public interface IUserProfileService
    {
        Task<List<GameViewModel>> GetOwnedGamesAsync(int userId);
        Task<List<GameSaleViewModel>> GetPurchaseHistoryAsync(int userId);
        Task<UserViewModel> GetUserProfileAsync(int userId);
        Task<bool> RefundGameAsync(int userId, int gameId);
        Task<bool> UpdateUserProfileAsync(int userId, UserViewModel model);
    }
}
