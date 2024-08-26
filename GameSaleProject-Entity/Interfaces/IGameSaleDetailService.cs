using GameSaleProject_Entity.Entities;

namespace GameSaleProject_Entity.Interfaces
{
    public interface IGameSaleDetailService
    {
        Task<GameSaleDetail> GetGameSaleDetailByIdAsync(int gameSaleDetailId);
        Task RefundGameSaleDetailAsync(int gameSaleDetailId);

    }
}
