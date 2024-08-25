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

        public async Task<IActionResult> Index()
        {
            var userName = User.Identity.Name;

            // Retrieve all games, categories, and publishers
            var games = await _gameService.GetAllGamesAsync();
            var categories = await _categoryService.GetAllCategoriesAsync();
            var publishers = await _publisherService.GetAllPublishersAsync();

            games = games.Where(g => !g.IsDeleted).ToList();

            // Retrieve user's purchase history
            var userPurchases = await _gameSaleService.GetUserPurchasesAsync(userName);
            var purchasedGameIds = userPurchases.SelectMany(purchase => purchase.GameSaleDetails)
                                                .Select(detail => detail.GameId)
                                                .ToHashSet();


            var gameViewModels = games.Select(game => new GameViewModel
            {
                Id = game.Id,
                GameName = game.GameName,
                Price = game.Price,
                Discount = game.Discount,
                IsInLibrary = purchasedGameIds.Contains(game.Id),
                Images = game.Images.Select(img => new ImageViewModel
                {
                    Id = img.Id,
                    Name = img.Name,
                    ImageUrl = img.ImageUrl,
                    ImageType = img.ImageType
                }).ToList(),
            }).ToList();

            // Prepare the model for the view
            var model = new GameCategoryPublisherViewModel
            {
                Games = gameViewModels,
                Categories = categories,
                Publishers = publishers
            };

            return View(model);
        }


        public async Task<IActionResult> Detail(int id)
        {
            // Retrieve the game data
            var game = await _gameService.GetGameByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }


            var publisher = await _publisherService.GetPublisherByIdAsync(game.PublisherId);

            var reviews = await _reviewService.GetReviewsByGameIdAsync(id);

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
                Platform = game.Platform,
                Images = game.Images,
                Reviews = reviews,
                SystemRequirements = systemRequirements != null ? new SystemRequirementViewModel
                {
                    OS = systemRequirements.OS,
                    SystemProcessor = systemRequirements.SystemProcessor,
                    SystemMemory = systemRequirements.SystemMemory,
                    Storage = systemRequirements.Storage,
                    Graphics = systemRequirements.Graphics,
                    IsMinimum = systemRequirements.IsMinimum
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
        [Authorize(Roles = "Publisher, Admin")]
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
        public async Task<IActionResult> DeleteGame(int id)
        {
            var result = await _gameService.DeleteGameAsync(id);
            TempData["Message"] = result;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Publisher, Admin")]
        public async Task<IActionResult> DeleteImage(int imageId, int gameId)
        {
            // Fetch the game associated with the image
            var game = await _gameService.GetGameByIdAsync(gameId);
            if (game == null)
            {
                return NotFound();
            }

            // Find the image to be deleted
            var image = game.Images.FirstOrDefault(img => img.Id == imageId);
            if (image == null)
            {
                return NotFound();
            }

            // Remove the image from the collection
            game.Images.Remove(image);

            // Update the game with the updated image list
            var result = await _gameService.UpdateGameAsync(game);

            if (result != "Game updated successfully.")
            {
                TempData["Message"] = "Failed to delete the image.";
                return RedirectToAction("UpdateGame", new { id = gameId });
            }

            // Optionally, delete the image file from the server
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
