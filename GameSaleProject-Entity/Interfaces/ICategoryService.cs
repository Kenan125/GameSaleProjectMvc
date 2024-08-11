using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.ViewModels;

namespace GameSaleProject_Entity.Interfaces
{
    public interface ICategoryService 
    {
        Task<IEnumerable<CategoryViewModel>> GetAll();
    }
}
