using GameSaleProject_Entity.ViewModels;
using Microsoft.AspNetCore.Http;

namespace GameSaleProject_Entity.Interfaces
{
    public interface IGameService
    {

        Task<string> AddGameAsync(GameViewModel model);

        Task<string> UpdateGameAsync(GameViewModel model);

        Task<string> DeleteGameAsync(int gameId);
        Task<string> SoftDeleteGameAsync(int gameId);

        Task<GameViewModel> GetGameByIdAsync(int gameId);

        Task<List<GameViewModel>> GetAllGamesAsync(bool includeDeleted = false);
        Task<List<GameViewModel>> GetGamesAsync(string searchTerm, int? categoryId, bool includeDeleted);

        Task<List<GameViewModel>> SearchGamesAsync(string searchTerm, bool includeDeleted = false);

        Task<List<GameViewModel>> GetGamesByCategoryAsync(int categoryId, bool includeDeleted = false);
        Task<List<GameViewModel>> GetGamesByPublisherAsync(int publisherId);
        Task<List<ImageViewModel>> HandleImageUploads(IFormFile cardImage, List<IFormFile> displayImages);
    }
}
