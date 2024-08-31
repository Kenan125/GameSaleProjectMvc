using GameSaleProject_Entity.ViewModels;

namespace GameSaleProject_Entity.Interfaces
{
    public interface ISystemRequirementService
    {
        Task<SystemRequirementViewModel?> GetSystemRequirementsByGameIdAsync(int gameId);
        
    }
}
