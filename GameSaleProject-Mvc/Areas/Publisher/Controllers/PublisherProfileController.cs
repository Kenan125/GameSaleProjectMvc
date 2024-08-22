using GameSaleProject_Entity.Identity;
using GameSaleProject_Entity.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Areas.Publisher.Controllers
{
    [Area("Publisher")]
    public class PublisherProfileController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IPublisherService _publisherService;
        private readonly UserManager<AppUser> _userManager;
        public PublisherProfileController(IGameService gameService, IPublisherService publisherService, UserManager<AppUser> userManager)
        {
            _gameService = gameService;
            _publisherService = publisherService;
            _userManager = userManager;
        }

        
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ManageGames()
        {
            var userId = int.Parse(_userManager.GetUserId(User)); // Get the current user's Id

            var publisher = await _publisherService.GetPublisherByUserIdAsync(userId);
            if (publisher == null)
            {
                return RedirectToAction("Index", "Home"); // Or display an error message
            }

            var games = await _gameService.GetGamesByPublisherAsync(publisher.Id);
            return View(games);
        }
    }
}
