using GameSaleProject_DataAccess.Contexts;
using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
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

        public async Task<GameSale> GetGameSaleByIdAsync(int gameSaleId)
        {
            return await _context.GameSales
                .Include(gs => gs.GameSaleDetails)
                .ThenInclude(gsd => gsd.Game)
                .FirstOrDefaultAsync(gs => gs.Id == gameSaleId);
        }

        public async Task<List<GameSale>> GetUserPurchasesAsync(string userName)
        {
            return await _context.GameSales
                .Include(gs => gs.User) // Include the User to ensure it's loaded
                .Include(gs => gs.GameSaleDetails)
                    .ThenInclude(gsd => gsd.Game)
                    .ThenInclude(g=>g.Images)// Ensure Game is loaded as well
                .Where(gs => gs.User.UserName == userName) // Now this should work
                .ToListAsync();
        }
        public async Task RefundGameSaleAsync(int gameSaleId, int? gameSaleDetailId = null)
        {
            var gameSale = await GetGameSaleByIdAsync(gameSaleId);
            if (gameSale == null) return;

            if (gameSaleDetailId.HasValue)
            {
                // Handle individual game refund
                var gameSaleDetail = gameSale.GameSaleDetails.FirstOrDefault(gsd => gsd.Id == gameSaleDetailId.Value);
                if (gameSaleDetail != null && !gameSaleDetail.IsRefunded)
                {
                    gameSaleDetail.IsRefunded = true;
                }
            }
            else
            {
                // Handle full refund
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
