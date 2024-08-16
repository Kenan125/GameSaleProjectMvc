using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.ViewModels;

namespace GameSaleProject_Entity.Interfaces
{
    public interface IReviewService 
    {
        Task<List<ReviewViewModel>> GetReviewsByGameIdAsync(int gameId);
    }
}
