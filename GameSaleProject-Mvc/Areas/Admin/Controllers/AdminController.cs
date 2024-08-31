using GameSaleProject_DataAccess.Contexts;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Mvc.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameSaleProject_Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IGameService _gameService;
        private readonly IGameSaleService _gameSaleService;
        private readonly IAccountService _accountService;
        private readonly GameSaleProjectDbContext _context;
        public AdminController(IUserProfileService userProfileService, IGameService gameService, IGameSaleService gameSaleService, IAccountService accountService, GameSaleProjectDbContext context)
        {
            _userProfileService = userProfileService;
            _gameService = gameService;
            _gameSaleService = gameSaleService;
            _accountService = accountService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ActivePage = "Dashboard";
            
            var adminUser = await _accountService.FindByUserNameAsync(User.Identity.Name);
            var adminProfile = await _userProfileService.GetUserProfileAsync(adminUser.Id);

            
            var totalGames = await _context.Games.CountAsync();
            var totalUsers = (await _accountService.GetAllUsers()).Count;
            var totalSales = await _gameSaleService.GetTotalSalesCountAsync();
            var totalRevenue = await _gameSaleService.GetTotalRevenueAsync();
            
            var salesByDate = await _context.GameSales
    .GroupBy(gs => gs.CreatedDate.Date)
    .Select(group => new SalesByDateViewModel
    {
        Date = group.Key,
        TotalRevenue = group.Sum(gs => gs.TotalPrice)
    })
    .OrderBy(data => data.Date)
    .ToListAsync();

            var model = new AdminDashboardViewModel
            {
                AdminProfile = adminProfile,
                TotalGames = totalGames,
                TotalUsers = totalUsers,
                TotalSales = totalSales,
                TotalRevenue = totalRevenue,
                SalesByDate = salesByDate 
            };

            return View(model);
        }

        
        public async Task<IActionResult> ManageGames()
        {
            ViewBag.ActivePage = "ManageGames";
            var games = await _gameService.GetAllGamesAsync(true);
            return View(games);
        }
               

        
        public IActionResult ManageUsers()
        {
            return View();
        }

        [HttpPost]    
        public async Task<IActionResult> DeleteGame(int id)
        {
            var result = await _gameService.DeleteGameAsync(id);
            TempData["Message"] = result;
            return RedirectToAction("Index");
        }
    }
}
