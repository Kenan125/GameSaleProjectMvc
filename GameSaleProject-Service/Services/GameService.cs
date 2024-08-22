using AutoMapper;
using GameSaleProject_DataAccess.UnitOfWorks;
using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.UnitOfWorks;
using GameSaleProject_Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
            var game = await repository.GetByIdAsync(gameId);
            if (game == null)
            {
                return "Game not found.";
            }

            repository.Delete(game);
            await _unitOfWork.CommitAsync();
            return "Game deleted successfully.";
        }

        public async Task<List<GameViewModel>> GetAllGamesAsync()
        {
            var games = await _unitOfWork.GetRepository<Game>().GetAllAsync(
                includes: new Expression<Func<Game, object>>[]
                {
                    g => g.Images,
                    g => g.Reviews
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
                filter: g => g.CategoryId == categoryId
            );

            return _mapper.Map<List<GameViewModel>>(games);
        }

        public async Task<List<GameViewModel>> SearchGamesAsync(string searchTerm)
        {
            var games = await _unitOfWork.GetRepository<Game>().GetAllAsync(
                filter: g => g.GameName.Contains(searchTerm) || g.Description.Contains(searchTerm)
            );

            return _mapper.Map<List<GameViewModel>>(games);
        }

        public async Task<string> UpdateGameAsync(GameViewModel model)
        {
            var repository = _unitOfWork.GetRepository<Game>();
            var game = await repository.GetByIdAsync(model.Id);

            if (game == null)
                return "Game not found.";

            _mapper.Map(model, game);

            if (model.Images != null)
            {
                game.Images = _mapper.Map<List<Image>>(model.Images);
            }

            repository.Update(game);
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
    }
}
