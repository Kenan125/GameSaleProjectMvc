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
        private readonly IImageService _imageService;
        public PublisherProfileController(IGameService gameService, IPublisherService publisherService, UserManager<AppUser> userManager, IMapper mapper, IAccountService accountService, ICategoryService categoryService, IImageService imageService)
        {
            _gameService = gameService;
            _publisherService = publisherService;
            _userManager = userManager;
            _mapper = mapper;
            _accountService = accountService;
            _categoryService = categoryService;
            _imageService = imageService;
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
          
            var games = await _gameService.GetAllGamesAsync();

            var publisher = await _publisherService.GetPublisherByUserIdAsync(user.Id);

            var gameViewModels = games.Select(game => new GameViewModel
            {
                Id = game.Id,
                GameName = game.GameName,
                Price = game.Price,
                Discount = game.Discount,
                
                Images = game.Images.Select(img => new ImageViewModel
                {
                    Id = img.Id,
                    Name = img.Name,
                    ImageUrl = img.ImageUrl,
                    ImageType = img.ImageType
                }).ToList(),
            }).ToList();
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
        public async Task<IActionResult> UpdateGame(int gameId)
        {
            var user = await _accountService.FindByUserNameAsync(User.Identity.Name);
            

            var publisher = await _publisherService.GetPublisherByUserIdAsync(user.Id);
            

            var game = await _gameService.GetGameByIdAsync(gameId);
            

            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", game.CategoryId);

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



    }
}