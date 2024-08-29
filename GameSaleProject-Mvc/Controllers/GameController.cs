using AutoMapper;
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
        private readonly IMapper _mapper;

        public GameController(ILogger<GameController> logger, IGameService gameService, ICategoryService categoryService, IPublisherService publisherService, IReviewService reviewService, ISystemRequirementService systemRequirementService, IGameSaleService gameSaleService, IImageService imageService, IAccountService accountService, IMapper mapper)
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
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchTerm, int? categoryId)
        {
            // Determine if the user is an Admin
            bool isAdmin = User.IsInRole("Admin");

            // Get the games based on searchTerm or categoryId
            List<GameViewModel> games = await _gameService.GetGamesAsync(searchTerm, categoryId, isAdmin);

            // Fetch categories and publishers for the view model
            var categories = await _categoryService.GetAllCategoriesAsync();
            var publishers = await _publisherService.GetAllPublishersAsync();

            
            if (categoryId.HasValue)
            {
                // If a category is selected, fetch games by category
                var currentCategoryId = ViewData["CurrentCategoryId"] as int?;
                if (currentCategoryId.HasValue && currentCategoryId.Value == categoryId.Value)
                {
                    
                    ViewData["CurrentCategoryId"] = null;
                }
                else
                {
                    
                    ViewData["CurrentCategoryId"] = categoryId.Value;
                }
            }
            else
            {
                
                ViewData["CurrentCategoryId"] = null;
            }

            // Create the view model to pass to the view
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
    var userName = User.Identity.Name;

    var game = await _gameService.GetGameByIdAsync(id);
    if (game == null)
    {
        return NotFound();
    }

    var model = _mapper.Map<GameViewModel>(game);

    var userPurchases = await _gameSaleService.GetUserPurchasesAsync(userName);
    var purchasedGameIds = userPurchases.SelectMany(purchase => purchase.GameSaleDetails)
                                        .Select(detail => detail.GameId)
                                        .ToHashSet();
    model.IsInLibrary = purchasedGameIds.Contains(game.Id);

    var reviews = await _reviewService.GetReviewsByGameIdAsync(id);
    model.Reviews = reviews;

    return View(model);
}


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SubmitReview(ReviewViewModel reviewModel)
        {
            ModelState.Remove("User");
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Please ensure all required fields are filled.";
                return RedirectToAction("Detail", new { id = reviewModel.GameId });
            }

            try
            {
                await _reviewService.SubmitReviewAsync(reviewModel);
                TempData["Message"] = "Review submitted successfully.";
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred while submitting your review.";
            }

            return RedirectToAction("Detail", new { id = reviewModel.GameId });
        }


        [HttpGet]
        [Authorize(Roles = "Publisher, Admin")]
        public async Task<IActionResult> AddGame()
        {
            var user = await _accountService.FindByUserNameAsync(User.Identity.Name);

            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.ActivePage = "AddGame";

            // Check if the user is a Publisher
            if (User.IsInRole("Publisher"))
            {
                var publisher = await _publisherService.GetPublisherByUserIdAsync(user.Id);
                if (publisher == null)
                {
                    TempData["Error"] = "You are not associated with any publisher.";
                    return RedirectToAction("Index");
                }

                // Automatically set the PublisherId and hide the Publisher selection for publishers
                var model = new GameViewModel
                {
                    PublisherId = publisher.Id // Automatically set the PublisherId
                };

                return View(model); // Return the view with the model containing the PublisherId
            }

            // Admin view: load all publishers and pass them to the view
            ViewBag.Publishers = await _publisherService.GetAllPublishersAsync();
            if (ViewBag.Categories == null || ViewBag.Publishers == null)
            {
                TempData["Error"] = "Failed to load categories or publishers.";
                return RedirectToAction("Index");
            }

            return View(new GameViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> AddGame(GameViewModel model, IFormFile CardImage, List<IFormFile> DisplayImages)
        {
            ModelState.Remove("CardImage");
            ModelState.Remove("Category");
            ModelState.Remove("CategoryId");
            ModelState.Remove("SystemRequirement");
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
        public async Task<IActionResult> UpdateGame(int id, string returnUrl = null)
        {
            ViewBag.ActivePage = "ManageGames";
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
            ViewBag.ReturnUrl = returnUrl ?? Request.Headers["Referer"].ToString();
            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGame(GameViewModel model, IFormFile cardImage, List<IFormFile> DisplayImages, string returnUrl = null)
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
                    ViewBag.ReturnUrl = returnUrl ?? Request.Headers["Referer"].ToString();
                    return View(model);
                }
                if (result == "Publisher does not exist.")
                {
                    ModelState.AddModelError("PublisherId", "Selected publisher does not exist.");
                    ViewBag.ReturnUrl = returnUrl ?? Request.Headers["Referer"].ToString();
                    return View(model);
                }

                TempData["Message"] = result;

                return Redirect(returnUrl ?? Request.Headers["Referer"].ToString());
            }


            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Publishers = await _publisherService.GetAllPublishersAsync();
            ViewBag.ReturnUrl = returnUrl ?? Request.Headers["Referer"].ToString(); ;
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
