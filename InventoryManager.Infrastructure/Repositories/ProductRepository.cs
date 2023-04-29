using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventoryManagerContext? _context;

        public ProductRepository(InventoryManagerContext dbContext)
        {
            _context = dbContext;
        }

        public ProductRepository() { }

        public async Task<List<Product>> GetProductsListAsync()
        {
            return await _context!.Products!
                .Include(p => p.Category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await _context!.Products!.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateProductAsync(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            await _context!.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            var actualProduct = await _context!.Products!.SingleOrDefaultAsync(p => p.Id == product.Id);
            actualProduct!.Name = product.Name;
            actualProduct!.Description = product.Description;
            actualProduct!.TotalQuantity = product.TotalQuantity;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Product product)
        {
            var productToDelete = await _context!.Products!
                .Where(s => s.Id == product!.Id)
                .SingleOrDefaultAsync();
            _context.Remove(productToDelete!);
            await _context.SaveChangesAsync();
        }
    }
}
