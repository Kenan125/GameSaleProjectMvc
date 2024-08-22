using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Areas.Publisher.Controllers
{
    public class PublisherProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
