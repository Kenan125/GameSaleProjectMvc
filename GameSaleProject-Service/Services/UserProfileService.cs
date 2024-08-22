using GameSaleProject_DataAccess.Contexts;
using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Identity;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
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

        public async Task<bool> UpdateUserProfileAsync(int userId, UserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return false; // User not found
            }

            // Update profile picture URL if provided
            if (!string.IsNullOrEmpty(model.ProfilePictureUrl))
            {
                user.ProfilePictureUrl = model.ProfilePictureUrl;
            }

            // Update first name and last name
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            // Update username if provided and it's different from the current one
            if (!string.IsNullOrEmpty(model.UserName) && model.UserName != user.UserName)
            {
                var usernameExists = await _userManager.FindByNameAsync(model.UserName);
                if (usernameExists == null)
                {
                    user.UserName = model.UserName;
                }
                else
                {
                    return false; // Username already exists
                }
            }

            // Update phone number
            user.PhoneNumber = model.PhoneNumber;

            // Update password if both current and new passwords are provided
            if (!string.IsNullOrEmpty(model.CurrentPassword) && !string.IsNullOrEmpty(model.NewPassword))
            {
                var passwordChangeResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!passwordChangeResult.Succeeded)
                {
                    return false; // Password change failed
                }
            }

            // Update the user in the database
            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }
    }
}
