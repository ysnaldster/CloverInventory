using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;
using InventoryManager.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Application.Services
{
    public class ProductService : IGenericRestRepository<Product>
    {
        private readonly InventoryManagerContext? _context;

        public ProductService(InventoryManagerContext dbContext)
        {
            _context = dbContext;
        }

        public ProductService() { }

        public async Task<List<Product>> ItemList()
        {
            return await _context!.Products!
                .Include(p => p.Category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> FindItem(string id)
        {
            return (await _context!.Products!.SingleOrDefaultAsync(p => p.Id == id))!;
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
    }
}
