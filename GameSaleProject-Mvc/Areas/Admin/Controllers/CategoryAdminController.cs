using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Areas.Admin.Controllers
{
    public class CategoryAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
