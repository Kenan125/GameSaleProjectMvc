using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            var games = await _gameService.GetAllGamesAsync();
            var categories = await _categoryService.GetAllCategoriesAsync();
            var publishers = await _publisherService.GetAllPublishersAsync();

            games = games.Where(g => !g.IsDeleted).ToList();

            var model = new GameCategoryPublisherViewModel
            {
                Games = games,
                Categories = categories,
                Publishers = publishers
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddGame()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(GameViewModel model, IFormFile CardImage, List<IFormFile> DisplayImages)
        {
            if (ModelState.IsValid)
            {
                // Initialize the Images list
                model.Images = new List<ImageViewModel>();

                // Handle the card image upload
                if (CardImage != null && CardImage.Length > 0)
                {
                    var cardFileName = Path.GetFileNameWithoutExtension(CardImage.FileName);
                    var cardExtension = Path.GetExtension(CardImage.FileName);
                    var newCardFileName = $"{cardFileName}_{DateTime.Now.Ticks}{cardExtension}";
                    var cardPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newCardFileName);

                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")))
                    {
                        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images"));
                    }

                    using (var stream = new FileStream(cardPath, FileMode.Create))
                    {
                        await CardImage.CopyToAsync(stream);
                    }

                    model.Images.Add(new ImageViewModel
                    {
                        Name = newCardFileName,
                        ImageUrl = $"/images/{newCardFileName}",
                        ImageType = "card" // Set ImageType to "card"
                    });
                }

                // Handle the display images upload
                if (DisplayImages != null && DisplayImages.Count > 0)
                {
                    foreach (var file in DisplayImages)
                    {
                        if (file.Length > 0)
                        {
                            var displayFileName = Path.GetFileNameWithoutExtension(file.FileName);
                            var displayExtension = Path.GetExtension(file.FileName);
                            var newDisplayFileName = $"{displayFileName}_{DateTime.Now.Ticks}{displayExtension}";
                            var displayPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newDisplayFileName);

                            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")))
                            {
                                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images"));
                            }

                            using (var stream = new FileStream(displayPath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }

                            model.Images.Add(new ImageViewModel
                            {
                                Name = newDisplayFileName,
                                ImageUrl = $"/images/{newDisplayFileName}",
                                ImageType = "display" // Set ImageType to "display"
                            });
                        }
                    }
                }

                // Save the game with the images
                var result = await _gameService.AddGameAsync(model);
                TempData["Message"] = result;
                return RedirectToAction("Index");
            }

            return View(model);
        }


        public async Task<IActionResult> FilterByCategory(int categoryId)
        {
            var games = await _gameService.GetGamesByCategoryAsync(categoryId);
            return View("Index", games);
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
        public async Task<IActionResult> UpdateGame(GameViewModel model, List<IFormFile> Images)
        {
            if (ModelState.IsValid)
            {
                // Initialize model.Images if it's null
                model.Images = new List<ImageViewModel>();

                // Process image uploads
                foreach (var file in Images)
                {
                    if (file.Length > 0)
                    {
                        // Generate unique file name and save the file
                        var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                        var extension = Path.GetExtension(file.FileName);
                        var newFileName = $"{fileName}_{DateTime.Now.Ticks}{extension}";

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);

                        // Ensure the directory exists
                        if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images")))
                        {
                            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images"));
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

                var result = await _gameService.UpdateGameAsync(model);
                if (result == "Category does not exist.")
                {
                    ModelState.AddModelError("CategoryId", "Selected category does not exist.");
                    return View(model);
                }
                if (result == "Publisher does not exist.")
                {
                    ModelState.AddModelError("PublisherId", "Selected publisher does not exist.");
                    return View(model);
                }

                TempData["Message"] = result;
                return RedirectToAction("Index");
            }

            // Repopulate categories and publishers in case of validation errors
            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Publishers = await _publisherService.GetAllPublishersAsync();
            return View(model);
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
