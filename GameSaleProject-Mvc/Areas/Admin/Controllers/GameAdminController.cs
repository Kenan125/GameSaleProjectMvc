using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Areas.Admin.Controllers
{
    public class GameAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
