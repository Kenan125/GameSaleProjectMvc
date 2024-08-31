using GameSaleProject_Entity.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SalesController : Controller
    {
        private readonly IGameSaleService _gameSaleService;

        public SalesController(IGameSaleService gameSaleService)
        {
            _gameSaleService = gameSaleService;
        }

        
        public async Task<IActionResult> Index()
        {
            ViewBag.ActivePage = "SalesStats";
            var sales = await _gameSaleService.GetAllSalesAsync(); // Fetch all sales
            return View(sales);
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var sale = await _gameSaleService.GetGameSaleByIdAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            return View(sale);
        }
    }
}
