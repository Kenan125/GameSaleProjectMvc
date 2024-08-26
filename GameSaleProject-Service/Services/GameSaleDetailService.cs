using GameSaleProject_DataAccess.Contexts;
using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameSaleProject_Service.Services
{
    public class GameSaleDetailService : IGameSaleDetailService
    {
        private readonly GameSaleProjectDbContext _context;

        public GameSaleDetailService(GameSaleProjectDbContext context)
        {
            _context = context;
        }

        public async Task<GameSaleDetail> GetGameSaleDetailByIdAsync(int gameSaleDetailId)
        {
            return await _context.GameSaleDetails
                .Include(gsd => gsd.Game)
                .FirstOrDefaultAsync(gsd => gsd.Id == gameSaleDetailId);
        }
        public async Task RefundGameSaleDetailAsync(int gameSaleDetailId)
        {
            var gameSaleDetail = await GetGameSaleDetailByIdAsync(gameSaleDetailId);
            if (gameSaleDetail != null && !gameSaleDetail.IsRefunded)
            {
                gameSaleDetail.IsRefunded = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
