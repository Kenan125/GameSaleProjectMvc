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

        // Action to list all categories
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return View(categories);
        }

        // Action to load the Add/Edit form in the modal
        public async Task<IActionResult> AddCategory()
        {
            var model = new CategoryViewModel();
            return PartialView("_AddEditCategory", model); // Use the new partial view
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryViewModel category)
        {
            var result = await _categoryService.AddCategoryAsync(category);
            return RedirectToAction("Index", result);
        }
        public async Task<IActionResult> EditCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return PartialView("_AddEditCategory", category); // Use the new partial view
        }


        


        // Action to delete a category
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction("Index");
        }

        // Utility method to render a view as a string
        
    }
}
