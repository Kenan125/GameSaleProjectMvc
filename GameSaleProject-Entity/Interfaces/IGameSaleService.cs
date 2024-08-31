using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.ViewModels;

namespace GameSaleProject_Entity.Interfaces
{
    public interface IGameSaleService
    {
        Task CreateGameSaleAsync(GameSale gameSale);
        Task<GameSaleViewModel> GetGameSaleByIdAsync(int gameSaleId);
        Task<List<GameSaleViewModel>> GetUserPurchasesAsync(string userName);
        Task RefundGameSaleAsync(int gameSaleId, int? gameSaleDetailId = null);
        Task<int> GetTotalSalesCountAsync();
        Task<decimal> GetTotalRevenueAsync();
        Task<DateTime?> GetFirstGameSaleDateAsync();
        Task<List<GameSaleViewModel>> GetAllSalesAsync();
    }
}
