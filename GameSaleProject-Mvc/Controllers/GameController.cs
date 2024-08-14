using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using GameSaleProject_Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace GameSaleProject_Mvc.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGameService _gameService;
        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;

        public GameController(ILogger<GameController> logger, IGameService gameService, ICategoryService categoryService, IPublisherService publisherService)
        {
            _logger = logger;
            _gameService = gameService;
            _categoryService = categoryService;
            _publisherService = publisherService;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _gameService.GetAllGamesWithImagesAsync();
            var categories = await _categoryService.GetAllCategoriesAsync(); // Assuming you have a category service
            var publishers = await _publisherService.GetAllPublishersAsync();

            var model = new GameCategoryPublisherViewModel
            {
                Games = games,
                Categories = categories,
                Publishers = publishers
            };

            return View(model);
            //return View(games);
        }
        [HttpGet]
        public async Task<IActionResult> AddGame()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGame(GameViewModel model, List<IFormFile> Images)
        {
            if (ModelState.IsValid)
            {
                // Handle image uploads
                model.Images = new List<ImageViewModel>();
                foreach (var file in Images)
                {
                    if (file.Length > 0)
                    {
                        // Generate unique file name and save the file
                        var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                        var extension = Path.GetExtension(file.FileName);
                        var newFileName = $"{fileName}_{DateTime.Now.Ticks}{extension}";

                        // Correct the path to save the image in the correct directory
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);

                        // Ensure the directory exists
                        var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        // Add image details to the model
                        model.Images.Add(new ImageViewModel
                        {
                            Name = newFileName,
                            ImageUrl = $"/images/{newFileName}",
                        });
                    }
                }

                var result = await _gameService.AddGameAsync(model);
                TempData["Message"] = result;
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public async Task<IActionResult> FilterByCategory(int categoryId)
        {
            var games = await _gameService.GetGamesByCategoryAsync(categoryId);
            return View("Index", games); // Assuming you are reusing the Index view to display filtered games
        }

    }
}
