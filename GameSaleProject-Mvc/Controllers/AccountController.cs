﻿using GameSaleProject_DataAccess.Identity;
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
        public async Task<IActionResult> Register(RegisterViewModel model) 
        {
            if (ModelState.IsValid)
            {
                string profilePictureUrl = "/images/default-profile.png"; // Default picture

                if (model.ProfilePicture != null)
                {
                    var fileName = Path.GetFileNameWithoutExtension(model.ProfilePicture.FileName);
                    var extension = Path.GetExtension(model.ProfilePicture.FileName);
                    fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.ProfilePicture.CopyToAsync(stream);
                    }

                    profilePictureUrl = "/images/" + fileName;
                }

                model.ProfilePictureUrl = profilePictureUrl;

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
