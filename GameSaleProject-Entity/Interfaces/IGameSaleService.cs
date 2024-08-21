using GameSaleProject_Entity.Entities;

namespace GameSaleProject_Entity.Interfaces
{
    public interface IGameSaleService
    {
        Task CreateGameSaleAsync(GameSale gameSale);
        GameSale GetGameSaleById(int gameSaleId);
        Task<List<GameSale>> GetUserPurchasesAsync(string userName);
    }
}
