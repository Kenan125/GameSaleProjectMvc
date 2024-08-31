using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameSaleProject_Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        
        public async Task<IActionResult> Index()
        {
            ViewBag.ActivePage = "ManageCategories";
            var categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
        }

        
        public  IActionResult AddCategory()
        {
            var model = new CategoryViewModel();
            return PartialView("_AddCategory", model); 
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                 await _categoryService.AddCategoryAsync(category);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index"); 
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return PartialView("_UpdateCategory", category); 
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryViewModel model)
        {

            if (ModelState.IsValid) 
            {
                 await _categoryService.UpdateCategoryAsync(model);
            }
            return RedirectToAction("Index");
        }
        


        
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index");
        }

        
        
    }
}
