using GameSaleProject_DataAccess.Contexts;
using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Service.Services
{
    public class GameSaleService : IGameSaleService
    {
        private readonly GameSaleProjectDbContext _context;

        public GameSaleService(GameSaleProjectDbContext context)
        {
            _context = context;
        }

        public async Task CreateGameSaleAsync(GameSale gameSale)
        {
            _context.GameSales.Add(gameSale);
            await _context.SaveChangesAsync();
        }

        public async Task<GameSaleViewModel> GetGameSaleByIdAsync(int gameSaleId)
        {
            var gameSale = await _context.GameSales
                .Include(gs => gs.GameSaleDetails)
                .ThenInclude(gsd => gsd.Game)
                .FirstOrDefaultAsync(gs => gs.Id == gameSaleId);

            if (gameSale == null) 
            {
                return null;
            }
            // Map the GameSale entity to GameSaleViewModel
            var gameSaleViewModel = new GameSaleViewModel
            {
                Id = gameSale.Id,
                UserId = gameSale.UserId,
                UserName = gameSale.User.UserName,
                // Map other properties and nested properties like GameSaleDetails
            };

            return gameSaleViewModel;
        }

        public async Task<List<GameSaleViewModel>> GetUserPurchasesAsync(string userName)
        {
            var gameSales = await _context.GameSales
                .Include(gs => gs.User)
                .Include(gs => gs.GameSaleDetails)
                    .ThenInclude(gsd => gsd.Game)
                    .ThenInclude(g => g.Images)
                .Where(gs => gs.User.UserName == userName)
                .ToListAsync();

            // Map the list of GameSales to a list of GameSaleViewModels
            var gameSaleViewModels = gameSales.Select(gs => new GameSaleViewModel
            {
                Id = gs.Id,
                UserId = gs.UserId,
                UserName = gs.User.UserName,
                TotalQuantity = gs.TotalQuantity,
                TotalPrice = gs.TotalPrice,
                IsDiscountApplied = gs.IsDiscountApplied,
                IsFullyRefunded = gs.IsFullyRefunded,
                CreatedDate = gs.CreatedDate,
                IsDeleted = gs.IsDeleted,
                GameSaleDetails = gs.GameSaleDetails.Select(gsd => new GameSaleDetailViewModel
                {
                    Id = gsd.Id,
                    GameSaleId = gsd.GameSaleId,
                    GameId = gsd.GameId,
                    GameName = gsd.Game.GameName,
                    UnitPrice = gsd.UnitPrice,
                    Discount = gsd.Discount,
                    IsRefunded = gsd.IsRefunded,
                    CreatedDate = gsd.CreatedDate,
                    IsDeleted = gsd.IsDeleted,
                    Game = gsd.Game,
                    GameSale = gsd.GameSale
                }).ToList(),
                User = gs.User
            }).ToList();

            return gameSaleViewModels;
        }

        public async Task RefundGameSaleAsync(int gameSaleId, int? gameSaleDetailId = null)
        {
            var gameSale = await GetGameSaleByIdAsync(gameSaleId);
            if (gameSale == null) return;

            if (gameSaleDetailId.HasValue)
            {
                
                var gameSaleDetail = gameSale.GameSaleDetails.FirstOrDefault(gsd => gsd.Id == gameSaleDetailId.Value);
                if (gameSaleDetail != null && !gameSaleDetail.IsRefunded)
                {
                    gameSaleDetail.IsRefunded = true;
                }
            }
            else
            {
                
                foreach (var detail in gameSale.GameSaleDetails)
                {
                    detail.IsRefunded = true;
                }
                gameSale.IsFullyRefunded = true;
            }

            await _context.SaveChangesAsync();
        }
    }
}
