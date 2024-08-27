using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Controllers
{
    public class GameController : Controller
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGameService _gameService;
        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;
        private readonly IReviewService _reviewService;
        private readonly ISystemRequirementService _systemRequirementService;
        private readonly IGameSaleService _gameSaleService;
        private readonly IImageService _imageService;
        private readonly IAccountService _accountService;

        public GameController(ILogger<GameController> logger, IGameService gameService, ICategoryService categoryService, IPublisherService publisherService, IReviewService reviewService, ISystemRequirementService systemRequirementService, IGameSaleService gameSaleService, IImageService imageService, IAccountService accountService)
        {
            _logger = logger;
            _gameService = gameService;
            _categoryService = categoryService;
            _publisherService = publisherService;
            _reviewService = reviewService;
            _systemRequirementService = systemRequirementService;
            _gameSaleService = gameSaleService;
            _imageService = imageService;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchTerm, int? categoryId)
        {
            List<GameViewModel> games;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Perform search if a search term is provided
                games = await _gameService.SearchGamesAsync(searchTerm);
            }
            else if (categoryId.HasValue)
            {
                // If the same category is clicked, display all games
                var currentCategoryId = ViewData["CurrentCategoryId"] as int?;
                if (currentCategoryId.HasValue && currentCategoryId.Value == categoryId.Value)
                {
                    games = await _gameService.GetAllGamesAsync();
                    ViewData["CurrentCategoryId"] = null; // Reset the category filter
                }
                else
                {
                    // Filter games by the selected category
                    games = await _gameService.GetGamesByCategoryAsync(categoryId.Value);
                    ViewData["CurrentCategoryId"] = categoryId.Value; // Set the current category
                }
            }
            else
            {
                // Otherwise, retrieve all games
                games = await _gameService.GetAllGamesAsync();
                ViewData["CurrentCategoryId"] = null; // Ensure the category filter is reset
            }

            var categories = await _categoryService.GetAllCategoriesAsync();
            var publishers = await _publisherService.GetAllPublishersAsync();

            var model = new GameCategoryPublisherViewModel
            {
                Games = games,
                Categories = categories,
                Publishers = publishers
            };

            return View(model);
        }


        public async Task<IActionResult> Detail(int id)
        {

            var game = await _gameService.GetGameByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            var publisher = await _publisherService.GetPublisherByIdAsync(game.PublisherId);

            var reviews = await _reviewService.GetReviewsByGameIdAsync(id);
            var category = await _categoryService.GetCategoryByIdAsync(game.CategoryId);

            var systemRequirements = await _systemRequirementService.GetSystemRequirementsByGameIdAsync(id);

            var model = new GameViewModel
            {
                Id = game.Id,
                GameName = game.GameName,
                Description = game.Description,
                Price = game.Price,
                Discount = game.Discount,
                Developer = game.Developer,
                PublisherId = game.PublisherId,
                Publisher = publisher != null ? new PublisherViewModel { Id = publisher.Id, Name = publisher.Name } : null,
                CategoryId = game.CategoryId,
                Category = category != null ? new CategoryViewModel { Id = category.Id, Name = category.Name } : null,
                Platform = game.Platform,
                Images = game.Images,
                Reviews = reviews,
                SystemRequirements = systemRequirements != null ? new SystemRequirementViewModel
                {
                    OS = systemRequirements.OS,
                    SystemProcessor = systemRequirements.SystemProcessor,
                    SystemMemory = systemRequirements.SystemMemory,
                    Storage = systemRequirements.Storage,
                    Graphics = systemRequirements.Graphics
                    
                } : null
            };


            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Publisher, Admin")]
        public async Task<IActionResult> AddGame()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(GameViewModel model, IFormFile CardImage, List<IFormFile> DisplayImages)
        {
            if (ModelState.IsValid)
            {
                model.Images = await _gameService.HandleImageUploads(CardImage, DisplayImages);
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
        [Authorize(Roles = "Publisher, Admin,User")]
        public async Task<IActionResult> UpdateGame(int id)
        {

            var user = await _accountService.FindByUserNameAsync(User.Identity.Name);
            var game = await _gameService.GetGameByIdAsync(id);

            if (game == null)
                return NotFound();

            if (User.IsInRole("Publisher"))
            {
                var publisher = await _publisherService.GetPublisherByUserIdAsync(user.Id);
                if (game.PublisherId != publisher.Id)
                    return Forbid();
            }

            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Publishers = await _publisherService.GetAllPublishersAsync();

            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGame(GameViewModel model, IFormFile cardImage, List<IFormFile> DisplayImages)
        {
            ModelState.Remove("cardImage");
            ModelState.Remove("Category");
            ModelState.Remove("SystemRequirement");
            if (ModelState.IsValid)
            {

                model.Images = model.Images ?? new List<ImageViewModel>();


                if (cardImage != null && cardImage.Length > 0)
                {

                    model.Images = model.Images.Where(img => img.ImageType != "card").ToList();


                    var cardImageUrl = await _imageService.UploadImageAsync(cardImage, "card");
                    model.Images.Add(new ImageViewModel
                    {
                        Name = Path.GetFileName(cardImageUrl),
                        ImageUrl = cardImageUrl,
                        ImageType = "card"
                    });
                }


                foreach (var displayImage in DisplayImages)
                {
                    if (displayImage.Length > 0)
                    {
                        var displayImageUrl = await _imageService.UploadImageAsync(displayImage, "display");
                        model.Images.Add(new ImageViewModel
                        {
                            Name = Path.GetFileName(displayImageUrl),
                            ImageUrl = displayImageUrl,
                            ImageType = "display"
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


            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Publishers = await _publisherService.GetAllPublishersAsync();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Publisher, Admin")]
        public async Task<IActionResult> SoftDeleteGame(int id)
        {
            var result = await _gameService.SoftDeleteGameAsync(id);
            TempData["Message"] = result;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Publisher, Admin")]
        public async Task<IActionResult> DeleteImage(int imageId, int gameId)
        {
            var game = await _gameService.GetGameByIdAsync(gameId);
            if (game == null)
            {
                return NotFound();
            }

            var image = game.Images.FirstOrDefault(img => img.Id == imageId);
            if (image == null)
            {
                return NotFound();
            }

            game.Images.Remove(image);

            var result = await _gameService.UpdateGameAsync(game);

            if (result != "Game updated successfully.")
            {
                TempData["Message"] = "Failed to delete the image.";
                return RedirectToAction("UpdateGame", new { id = gameId });
            }

            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", image.ImageUrl.TrimStart('/'));
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            TempData["Message"] = "Image deleted successfully.";
            return RedirectToAction("UpdateGame", new { id = gameId });
        }

    }
}
