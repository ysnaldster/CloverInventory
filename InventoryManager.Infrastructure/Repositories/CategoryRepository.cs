using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Infrastructure.Repositories
{
    public class CategoryRepository : IGenericRestRepository<Category>
    {
        private readonly InventoryManagerContext? _context;

        public CategoryRepository(InventoryManagerContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Category>> ItemList()
        {
            return await _context!.Categories!.AsNoTracking().ToListAsync();
        }

        public async Task CreateItem(Category? category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            await _context!.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(Category? category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            var actualCategory = await _context!.Categories!.SingleOrDefaultAsync(p => p.Id == category.Id);
            actualCategory!.Name = category.Name;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(Category? category)
        {
            var categoryToDelete = await _context!.Categories!
                .Where(s => s.Id == category!.Id)
                .SingleOrDefaultAsync();
            _context.Remove(categoryToDelete!);
            await _context.SaveChangesAsync();
        }

        public Task<Category> Item(int id)
        {
            throw new NotImplementedException();
        }
    }
}
