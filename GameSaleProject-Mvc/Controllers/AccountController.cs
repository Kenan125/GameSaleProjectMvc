using GameSaleProject_Entity.Identity;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(IAccountService accountService, SignInManager<AppUser> signInManager)
        {
            _accountService = accountService;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(string? ReturnUrl)
        {
            LoginViewModel model = new LoginViewModel()
            {
                ReturnUrl = ReturnUrl ?? Url.Content("~/") // Default to home page if null
            };
            TempData["message"] = null;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string result = await _accountService.FindByNameAsync(model);

                if (result == "OK")
                {
                    
                    
                        return RedirectToAction("Index", "Home");
                    
                }
                else
                {
                    ModelState.AddModelError("", result);
                }
            }

            return View(model);
        }
        public IActionResult Register() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, IFormFile formFile)
        {
            // Set the default profile picture URL before any validation
            model.ProfilePictureUrl = "/images/DefaultPfp.png";
            // Remove the formFile from ModelState validation
            ModelState.Remove("formFile");
            if (ModelState.IsValid)
            {
                if (formFile != null && formFile.Length > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(formFile.FileName);
                    var extension = Path.GetExtension(formFile.FileName);
                    var newFileName = $"{fileName}_{DateTime.Now.Ticks}{extension}";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                    // Override the default URL with the uploaded file's URL
                    model.ProfilePictureUrl = "/images/" + newFileName;
                }

                string msg = await _accountService.CreateUserAsync(model);
                if (msg == "OK")
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", msg);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
