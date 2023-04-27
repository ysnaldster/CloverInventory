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
    public class ProductRepository : IGenericRestRepository<Product>
    {
        private readonly InventoryManagerContext? _context;

        public ProductRepository(InventoryManagerContext dbContext)
        {
            _context = dbContext;
        }

        public ProductRepository() { }


        public async Task<List<Product>> ItemList()
        {
            return await _context!.Products!
                .Include(p => p.Category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task CreateItem(Product? product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            await _context!.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(Product? product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            var actualProduct = await _context!.Products!.SingleOrDefaultAsync(p => p.Id == product.Id);
            actualProduct!.Name = product.Name;
            actualProduct!.Description = product.Description;
            actualProduct!.TotalQuantity = product.TotalQuantity;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(Product? product)
        {
            var productToDelete = await _context!.Products!
                .Where(s => s.Id == product!.Id)
                .SingleOrDefaultAsync();
            _context.Remove(productToDelete!);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> Item(int id)
        {
            return (await _context!.Products!.SingleOrDefaultAsync(p => p.Id == id))!;
        }
    }
}
