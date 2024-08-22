using GameSaleProject_Entity.Entities;

namespace GameSaleProject_Entity.Interfaces
{
    public interface IGameSaleService
    {
        Task CreateGameSaleAsync(GameSale gameSale);
        Task<GameSale> GetGameSaleByIdAsync(int gameSaleId);
        Task<List<GameSale>> GetUserPurchasesAsync(string userName);
        Task RefundGameSaleAsync(int gameSaleId, int? gameSaleDetailId = null);
    }
}
