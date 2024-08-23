﻿using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.ViewModels;
using Microsoft.AspNetCore.Http;

namespace GameSaleProject_Entity.Interfaces
{
    public interface IGameService 
    {

        Task<string> AddGameAsync(GameViewModel model);

        Task<string> UpdateGameAsync(GameViewModel model);

        Task<string> DeleteGameAsync(int gameId);

        Task<GameViewModel> GetGameByIdAsync(int gameId);

        Task<List<GameViewModel>> GetAllGamesAsync();

        Task<List<GameViewModel>> SearchGamesAsync(string searchTerm);
       
        Task<List<GameViewModel>> GetGamesByCategoryAsync(int categoryId);
        Task<List<GameViewModel>> GetGamesByPublisherAsync(int publisherId);
        Task<List<ImageViewModel>> HandleImageUploads(IFormFile cardImage, List<IFormFile> displayImages);
    }
}
