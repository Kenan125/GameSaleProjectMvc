using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            return View();
        }
        public IActionResult Register() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model) 
        {
            string msg = await _accountService.CreateUserAsync(model);
            if (msg == "Ok")
            {
                return RedirectToAction("Login");
            }
            else 
            {
                ModelState.AddModelError("",msg);
            }
            return View(model);
        }
        public IActionResult Logout()
        {

            return RedirectToAction("Index", "Home");
        }
    }
}
