using AutoMapper;
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
        public async Task<List<GameViewModel>> GetAllGamesAsync(bool includeDeleted = false)
        {
            var games = await _unitOfWork.GetRepository<Game>().GetAllAsync(
                filter: g => includeDeleted || !g.IsDeleted, // Include soft-deleted games based on the flag
                includes: new Expression<Func<Game, object>>[]
                {
            g => g.Images,
            g => g.Reviews,
            g => g.Category,
            g => g.SystemRequirement,
            g => g.Publisher
                }
            );

            return _mapper.Map<List<GameViewModel>>(games);
        }
        public async Task<List<GameViewModel>> GetGamesAsync(string searchTerm, int? categoryId, bool includeDeleted)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                return await SearchGamesAsync(searchTerm, includeDeleted);
            }

            if (categoryId.HasValue)
            {
                return await GetGamesByCategoryAsync(categoryId.Value, includeDeleted);
            }

            return await GetAllGamesAsync(includeDeleted);
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
            g => g.Publisher,
            g=>g.SystemRequirement,
            g=>g.Category
                }
            );

            if (game == null || !game.Any())
            {
                return null;
            }

            var gameViewModel = _mapper.Map<GameViewModel>(game.FirstOrDefault());

            return gameViewModel;
        }

        public async Task<List<GameViewModel>> GetGamesByCategoryAsync(int categoryId, bool includeDeleted = false)
        {
            var games = await _unitOfWork.GetRepository<Game>().GetAllAsync(
                filter: g => (includeDeleted || !g.IsDeleted) && g.CategoryId == categoryId, // Include deleted games based on the parameter
                includes: g => g.Images
            );

            return _mapper.Map<List<GameViewModel>>(games);
        }

        public async Task<List<GameViewModel>> SearchGamesAsync(string searchTerm, bool includeDeleted = false)
        {
            searchTerm = searchTerm.ToLower();

            var games = await _unitOfWork.GetRepository<Game>().GetAllAsync(
                filter: g => (includeDeleted || !g.IsDeleted) &&
                             (g.GameName.ToLower().Contains(searchTerm) ||
                              g.Description.ToLower().Contains(searchTerm)),
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
            // Handle SystemRequirements
            if (model.SystemRequirement != null)
            {
                var existingSystemRequirement = (await _unitOfWork.GetRepository<SystemRequirement>()
                                                  .GetAllAsync(sr => sr.GameId == model.Id))
                                                  .FirstOrDefault();
                if (existingSystemRequirement != null)
                {
                    existingSystemRequirement.SystemProcessor = model.SystemRequirement.SystemProcessor;
                    existingSystemRequirement.SystemMemory = model.SystemRequirement.SystemMemory;
                    existingSystemRequirement.Storage = model.SystemRequirement.Storage;
                    existingSystemRequirement.Graphics = model.SystemRequirement.Graphics;
                    existingSystemRequirement.OS = model.SystemRequirement.OS;

                    _unitOfWork.GetRepository<SystemRequirement>().Update(existingSystemRequirement);
                }
                else
                {
                    // Add new SystemRequirements if it doesn't exist
                    var newSystemRequirement = _mapper.Map<SystemRequirement>(model.SystemRequirement);
                    newSystemRequirement.GameId = model.Id; // Ensure the correct GameId is assigned
                    await _unitOfWork.GetRepository<SystemRequirement>().Add(newSystemRequirement);
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
