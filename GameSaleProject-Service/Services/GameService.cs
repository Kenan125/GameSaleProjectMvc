﻿using AutoMapper;
using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.UnitOfWorks;
using GameSaleProject_Entity.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace GameSaleProject_Service.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public GameService(IUnitOfWork uow, IMapper mapper, IImageService imageService)
        {
            _unitOfWork = uow;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task<string> AddGameAsync(GameViewModel model)
        {
            var game = _mapper.Map<Game>(model);

            if (model.Images?.Any() == true)
            {
                game.Images = model.Images.Select(img => new Image
                {
                    Name = img.Name,
                    ImageUrl = img.ImageUrl,
                    ImageType = img.ImageType,
                    CreatedDate = DateTime.Now
                }).ToList();
            }

            await _unitOfWork.GetRepository<Game>().Add(game);
            await _unitOfWork.CommitAsync();
            return "Game added successfully.";
        }

        public async Task<string> DeleteGameAsync(int gameId)
        {
            var repository = _unitOfWork.GetRepository<Game>();

            // This ensures that the hard delete method is called
            repository.Delete(gameId);

            await _unitOfWork.CommitAsync();
            return "Game deleted successfully.";
        }

        public async Task<string> SoftDeleteGameAsync(int gameId)
        {
            var repository = _unitOfWork.GetRepository<Game>();
            var game = await repository.GetByIdAsync(gameId);
            if (game == null)
            {
                return "Game not found.";
            }

            // Update the IsDeleted property to true instead of deleting the record
            game.IsDeleted = true;

            // Update the game in the repository
            repository.Update(game);

            // Commit the changes to the database
            await _unitOfWork.CommitAsync();

            return "Game marked as deleted successfully.";
        }
        public async Task<List<GameViewModel>> GetAllGamesAsync()
        {
            var games = await _unitOfWork.GetRepository<Game>().GetAllAsync(
                includes: new Expression<Func<Game, object>>[]
                {
                    g => g.Images,
                    g => g.Reviews,
                    g => g.Category,
                    g=> g.SystemRequirement,
                    g=>g.Publisher
                    
                }
            );

            return _mapper.Map<List<GameViewModel>>(games);
        }

        public async Task<GameViewModel> GetGameByIdAsync(int gameId)
        {
            var repository = _unitOfWork.GetRepository<Game>();
            var game = await repository.GetAllAsync(
                filter: g => g.Id == gameId,
                includes: new Expression<Func<Game, object>>[]
                {
            g => g.Images,
            g => g.Reviews,
            g => g.Publisher
                }
            );

            if (game == null || !game.Any())
            {
                return null;
            }

            var gameViewModel = _mapper.Map<GameViewModel>(game.FirstOrDefault());

            return gameViewModel;
        }

        public async Task<List<GameViewModel>> GetGamesByCategoryAsync(int categoryId)
        {
            var games = await _unitOfWork.GetRepository<Game>().GetAllAsync(
                filter: g => g.CategoryId == categoryId,
                includes: g=>g.Images
                
            );

            return _mapper.Map<List<GameViewModel>>(games);
        }

        public async Task<List<GameViewModel>> SearchGamesAsync(string searchTerm)
        {
            searchTerm = searchTerm.ToLower();

            var games = await _unitOfWork.GetRepository<Game>().GetAllAsync(
                filter: g => g.GameName.ToLower().Contains(searchTerm) ||
                             g.Description.ToLower().Contains(searchTerm),
                includes: new Expression<Func<Game, object>>[]
                {
            g => g.Images,
            g => g.Reviews,
            g => g.Publisher
                }
            );

            return _mapper.Map<List<GameViewModel>>(games);
        }


        public async Task<string> UpdateGameAsync(GameViewModel model)
        {
            var game = await _unitOfWork.GetRepository<Game>().GetByIdAsync(model.Id);

            if (game == null)
                return "Game not found.";

            _mapper.Map(model, game);

            if (model.Images != null && model.Images.Any())
            {
                game.Images.RemoveAll(img => !model.Images.Any(m => m.Id == img.Id));

                foreach (var modelImage in model.Images)
                {
                    var existingImage = game.Images.FirstOrDefault(img => img.Id == modelImage.Id);
                    if (existingImage != null)
                        _mapper.Map(modelImage, existingImage);
                    else
                        game.Images.Add(_mapper.Map<Image>(modelImage));
                }
            }

            _unitOfWork.GetRepository<Game>().Update(game);
            await _unitOfWork.CommitAsync();

            return "Game updated successfully.";
        }

        public async Task<List<GameViewModel>> GetGamesByPublisherAsync(int publisherId)
        {
            var games = await _unitOfWork.GetRepository<Game>().GetAllAsync(
                filter: g => g.PublisherId == publisherId,
                includes: g => g.Images
            );

            return _mapper.Map<List<GameViewModel>>(games);
        }
        public async Task<List<ImageViewModel>> HandleImageUploads(IFormFile cardImage, List<IFormFile> displayImages)
        {
            var images = new List<ImageViewModel>();

            if (cardImage != null)
            {
                var cardImageUrl = await _imageService.UploadImageAsync(cardImage, "card");
                images.Add(new ImageViewModel
                {
                    Name = Path.GetFileName(cardImageUrl),
                    ImageUrl = cardImageUrl,
                    ImageType = "card"
                });
            }

            foreach (var displayImage in displayImages)
            {
                if (displayImage.Length > 0)
                {
                    var displayImageUrl = await _imageService.UploadImageAsync(displayImage, "display");
                    images.Add(new ImageViewModel
                    {
                        Name = Path.GetFileName(displayImageUrl),
                        ImageUrl = displayImageUrl,
                        ImageType = "display"
                    });
                }
            }

            return images;
        }

    }
}
