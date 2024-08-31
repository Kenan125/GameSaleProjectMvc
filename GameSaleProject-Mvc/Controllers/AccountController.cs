using GameSaleProject_Entity.Identity;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(IAccountService accountService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _accountService = accountService;
            _signInManager = signInManager;
            _userManager = userManager;
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
                ReturnUrl = ReturnUrl ?? Url.Content("~/")
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
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);

                    if (signInResult.Succeeded)
                    {

                        return LocalRedirect(model.ReturnUrl ?? Url.Content("~/"));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid login attempt.");
                    }
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
            model.ProfilePictureUrl = "/images/DefaultPfp.png";
            ModelState.Remove("formFile");

            if (ModelState.IsValid)
            {
                if (formFile != null && formFile.Length > 0)
                {
                    model.ProfilePictureUrl = await _accountService.SaveProfilePictureAsync(formFile);
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
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
