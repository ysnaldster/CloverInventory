using InventoryManager.Domain.Entities;

namespace InventoryManager.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsListAsync();
        Task<Product?> GetProductAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);
    }
}
