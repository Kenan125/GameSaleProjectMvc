using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameSaleProject_Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RoleController : Controller
    {
        private readonly IAccountService _accountService;

        public RoleController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _accountService.GetAllRoles();
            return View(roles);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            string msg = await _accountService.CreateRoleAsync(model);
            if (msg == "OK")
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", msg);
            }
            return View(model);
        }

        
        public async Task<IActionResult> Delete(string id)
        {
            await _accountService.DeleteRoleAsync(id);
            return RedirectToAction("Index");
        }
    }
}
