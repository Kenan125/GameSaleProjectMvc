using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
