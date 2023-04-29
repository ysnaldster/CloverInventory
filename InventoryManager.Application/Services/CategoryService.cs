using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;

namespace InventoryManager.Application.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _categoryRepository!.GetCategoriesListAsync();
        }
    }
}
