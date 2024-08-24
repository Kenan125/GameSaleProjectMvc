using AutoMapper;
using GameSaleProject_Entity.Identity;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using GameSaleProject_Service.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameSaleProject_Mvc.Areas.Publisher.Controllers
{
    [Area("Publisher")]
    public class PublisherProfileController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IPublisherService _publisherService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;
        private readonly ICategoryService _categoryService;
        public PublisherProfileController(IGameService gameService, IPublisherService publisherService, UserManager<AppUser> userManager, IMapper mapper, IAccountService accountService, ICategoryService categoryService)
        {
            _gameService = gameService;
            _publisherService = publisherService;
            _userManager = userManager;
            _mapper = mapper;
            _accountService = accountService;
            _categoryService = categoryService;
        }
        private async Task<UserViewModel?> GetAuthenticatedUserAsync()
        {
            var userName = User.Identity.Name;

            if (string.IsNullOrEmpty(userName))
            {
                return null;
            }

            return await _accountService.FindByUserNameAsync(userName);
        }
        private void SetActivePage(string pageName)
        {
            ViewBag.ActivePage = pageName;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await GetAuthenticatedUserAsync();

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var publisher = await _publisherService.GetPublisherByUserIdAsync(user.Id);

            if (publisher == null)
            {
                return RedirectToAction("BecomePublisher", "UserProfile", new { area = "User" });
            }

            return View(publisher);
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
        [HttpGet]
        public async Task<IActionResult> AddGame()
        {
            var categories = await _categoryService.GetAllCategoriesAsync(); // Assume this method returns a list of categories


            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            var user = await _accountService.FindByUserNameAsync(User.Identity.Name);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var publisher = await _publisherService.GetPublisherByUserIdAsync(user.Id);
            if (publisher == null)
            {
                return RedirectToAction("BecomePublisher", "UserProfile", new { area = "User" });
            }
            var model = new GameViewModel
            {
                PublisherId = publisher.Id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(GameViewModel model, IFormFile cardImage, List<IFormFile> displayImages)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _accountService.FindByUserNameAsync(User.Identity.Name);
            if (user == null)
            {
                return RedirectToAction("Login", "Account", new { area = "User" });
            }

            var publisher = await _publisherService.GetPublisherByUserIdAsync(user.Id);
            if (publisher == null)
            {
                return RedirectToAction("BecomePublisher", "UserProfile", new { area = "User" });
            }

            // Assign the PublisherId to the model
            model.PublisherId = publisher.Id;

            // Handle image uploads
            model.Images = await _gameService.HandleImageUploads(cardImage, displayImages);

            var result = await _gameService.AddGameAsync(model);

            if (result == "Game added successfully.")
            {
                return RedirectToAction("Index", new { Message = "Game added successfully." });
            }

            ModelState.AddModelError("", "Failed to add the game. Please try again.");
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> UpdateGame(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            var categories = await _categoryService.GetAllCategoriesAsync();
            var publishers = await _publisherService.GetAllPublishersAsync();

            ViewBag.Categories = categories;
            ViewBag.Publishers = publishers;

            return View(game);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGame(GameViewModel model, IFormFile CardImage, List<IFormFile> displayImages)
        {
            if (!ModelState.IsValid)
            {
                model.Images = await _gameService.HandleImageUploads(CardImage, displayImages);
                var result = await _gameService.UpdateGameAsync(model);
                ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();

                TempData["Message"] = result;
                return RedirectToAction("Index");

            }
            return View(model);
        }
    }
}