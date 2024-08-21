using GameSaleProject_DataAccess.Contexts;
using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Identity;
using GameSaleProject_Entity.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Service.Services
{
    public class UserProfileService: IUserProfileService
    {
        private readonly GameSaleProjectDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserProfileService(GameSaleProjectDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<Game>> GetOwnedGamesAsync(int userId)
        {
            var gameSales = await _context.GameSales
                .Include(gs => gs.GameSaleDetails)
                .ThenInclude(gsd => gsd.Game)
                .Where(gs => gs.UserId == userId)
                .ToListAsync();

            var ownedGames = gameSales.SelectMany(gs => gs.GameSaleDetails.Select(gsd => gsd.Game))
                                      .Distinct()
                                      .ToList();

            return ownedGames;
        }
        public async Task<List<GameSale>> GetPurchaseHistoryAsync(int userId)
        {
            var purchaseHistory = await _context.GameSales
                .Include(gs => gs.GameSaleDetails)
                .ThenInclude(gsd => gsd.Game)
                .Where(gs => gs.UserId == userId)
                .OrderByDescending(gs => gs.CreatedDate)
                .ToListAsync();

            return purchaseHistory;
        }
        public async Task<AppUser> GetUserProfileAsync(int userId)
        {
            var user = await _userManager.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<bool> RefundGameAsync(int userId, int gameId)
        {
            var gameSaleDetail = await _context.GameSaleDetails
                .Include(gsd => gsd.GameSale)
                .FirstOrDefaultAsync(gsd => gsd.GameId == gameId && gsd.GameSale.UserId == userId && !gsd.IsRefunded);

            if (gameSaleDetail != null)
            {
                gameSaleDetail.IsRefunded = true;
                _context.GameSaleDetails.Update(gameSaleDetail);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
