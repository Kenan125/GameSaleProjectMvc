using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Areas.User.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
