using InventoryManager.Domain.Entities;

namespace InventoryManager.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesListAsync();
    }
}
