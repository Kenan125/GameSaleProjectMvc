using GameSaleProject_Entity.ViewModels;

namespace GameSaleProject_Entity.Interfaces
{
    public interface ICategoryService
    {

        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
        Task<CategoryViewModel> GetCategoryByIdAsync(int categoryId);
        Task<string> AddCategoryAsync(CategoryViewModel model);
        Task UpdateCategoryAsync(CategoryViewModel model);
        Task DeleteCategoryAsync(int categoryId);
    }
}
