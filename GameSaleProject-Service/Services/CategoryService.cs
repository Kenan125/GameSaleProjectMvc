using AutoMapper;
using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.UnitOfWorks;
using GameSaleProject_Entity.ViewModels;

namespace GameSaleProject_Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            var categoryRepository = _unitOfWork.GetRepository<Category>();
            var categories = await categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
        }
        public async Task<CategoryViewModel> GetCategoryByIdAsync(int categoryId)
        {
            var repository =  _unitOfWork.GetRepository<Category>();
            var category = await repository.GetByIdAsync(categoryId);
            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
            return categoryViewModel;
        }

        public async Task AddCategoryAsync(CategoryViewModel model)
        {
            var category = _mapper.Map<Category>(model);
            await _unitOfWork.GetRepository<Category>().Add(category);
            await _unitOfWork.CommitAsync();
            
        }

        public async Task UpdateCategoryAsync(CategoryViewModel model)
        {
            var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(model.Id);
            
                _mapper.Map(model, category);
                _unitOfWork.GetRepository<Category>().Update(category);
                await _unitOfWork.CommitAsync();
            
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            _unitOfWork.GetRepository<Category>().Delete(categoryId);
            await _unitOfWork.CommitAsync();
        }
    }
}
