using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly InventoryManagerContext? _context;

        public CategoryRepository(InventoryManagerContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Category>> GetCategoriesListAsync()
        {
            return await _context!.Categories!.AsNoTracking().ToListAsync();
        }     
    }
}
