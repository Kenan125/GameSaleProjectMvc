using AutoMapper;
using GameSaleProject_DataAccess.Contexts;
using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Identity;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.UnitOfWorks;
using GameSaleProject_Entity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameSaleProject_Service.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly GameSaleProjectDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserProfileService(GameSaleProjectDbContext context, UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GameViewModel>> GetOwnedGamesAsync(int userId)
        {
            var gameSales = await _context.GameSales
                .Include(gs => gs.GameSaleDetails)
                .ThenInclude(gsd => gsd.Game)
                .Where(gs => gs.UserId == userId)
                .ToListAsync();

            var ownedGames = gameSales.SelectMany(gs => gs.GameSaleDetails.Select(gsd => gsd.Game))
                                      .Distinct()
                                      .ToList();

            return _mapper.Map<List<GameViewModel>>(ownedGames);
        }
        public async Task<List<GameSaleViewModel>> GetPurchaseHistoryAsync(int userId)
        {
            var purchaseHistory = await _context.GameSales
                .Include(gs => gs.GameSaleDetails)
                .ThenInclude(gsd => gsd.Game)
                .Where(gs => gs.UserId == userId)
                .OrderByDescending(gs => gs.CreatedDate)
                .ToListAsync();

            return _mapper.Map<List<GameSaleViewModel>>(purchaseHistory);
        }
        public async Task<UserViewModel> GetUserProfileAsync(int userId)
        {
            var user = await _userManager.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            return _mapper.Map<UserViewModel>(user);
        }
        public async Task<int?> FindUserIdByUserNameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return user?.Id;
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
                return false;
            }

            if (!string.IsNullOrEmpty(model.ProfilePictureUrl))
            {
                user.ProfilePictureUrl = model.ProfilePictureUrl;
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;

            if (!string.IsNullOrEmpty(model.UserName) && model.UserName != user.UserName)
            {
                var usernameExists = await _userManager.FindByNameAsync(model.UserName);
                if (usernameExists == null)
                {
                    user.UserName = model.UserName;
                }
                else
                {
                    return false;
                }
            }

            user.PhoneNumber = model.PhoneNumber;

            if (!string.IsNullOrEmpty(model.CurrentPassword) && !string.IsNullOrEmpty(model.NewPassword))
            {
                var passwordChangeResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!passwordChangeResult.Succeeded)
                {
                    return false; // Password change failed
                }
            }

            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }


        public async Task DeleteUserAndRelatedDataAsync(int userId)
        {
            var publisher = await _unitOfWork.GetRepository<Publisher>()
                                             .Get(p => p.UserId == userId);

            if (publisher != null)
            {

                var games = await _unitOfWork.GetRepository<Game>()
                                             .GetAllAsync(g => g.PublisherId == publisher.Id);
                foreach (var game in games)
                {
                    _unitOfWork.GetRepository<Game>().Delete(game);
                }


                _unitOfWork.GetRepository<Publisher>().Delete(publisher);
            }


            var user = await _unitOfWork.GetRepository<AppUser>().GetByIdAsync(userId);
            if (user != null)
            {
                _unitOfWork.GetRepository<AppUser>().Delete(user);
            }

            await _unitOfWork.CommitAsync();
        }

    }
}
