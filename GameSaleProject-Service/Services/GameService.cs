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
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Service.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GameService(IUnitOfWork uow, IMapper mapper)
        {
            _unitOfWork = uow;
            _mapper = mapper;
        }


        public async Task<string> AddGameAsync(GameViewModel model)
        {
            var game = _mapper.Map<Game>(model);
            var repository = _unitOfWork.GetRepository<Game>();
            await repository.Add(game);
            _unitOfWork.Commit();
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
            _unitOfWork.Commit();
            return "Game deleted successfully.";
        }

        public async Task<List<GameViewModel>> GetAllGamesAsync()
        {
            var repository = _unitOfWork.GetRepository<Game>();
            var games = await repository.GetAllAsync();
            return _mapper.Map<List<GameViewModel>>(games);
        }

        public async Task<GameViewModel> GetGameByIdAsync(int gameId)
        {
            var repository = _unitOfWork.GetRepository<Game>();
            var game = await repository.GetByIdAsync(gameId);
            if (game == null)
            {
                return null;
            }

            return _mapper.Map<GameViewModel>(game);

        }

        public async Task<List<GameViewModel>> GetGamesByCategoryAsync(int categoryId)
        {
            var repository = _unitOfWork.GetRepository<Game>();
            var games = await repository.GetAll(
                filter: g => g.CategoryId == categoryId // Assuming "CategoryId" is a foreign key in Game entity
            );
            return _mapper.Map<List<GameViewModel>>(games);
        }

        

        public async Task<List<GameViewModel>> SearchGamesAsync(string searchTerm)
        {
            var repository = _unitOfWork.GetRepository<Game>();
            var games = await repository.GetAll(
                filter: g => g.GameName.Contains(searchTerm) || g.Description.Contains(searchTerm)
            );
            return _mapper.Map<List<GameViewModel>>(games);
        }

        public async Task<string> UpdateGameAsync(GameViewModel model)
        {
            var repository = _unitOfWork.GetRepository<Game>();
            var game = await repository.GetByIdAsync(model.Id);
            if (game == null)
            {
                return "Game not found.";
            }

            _mapper.Map(model, game);
            repository.Update(game);
            _unitOfWork.Commit();
            return "Game updated successfully.";
        }
        public async Task<List<GameViewModel>> GetAllGamesWithImagesAsync()
        {
            var repository = _unitOfWork.GetRepository<Game>();
            var games = await repository.GetAll(
                includes: new Expression<Func<Game, object>>[]
                {
            g => g.Images,
            g => g.Reviews
                }
            );
            return _mapper.Map<List<GameViewModel>>(games);
        }
    }
}
