using InventoryManager.Domain.Entities;

namespace InventoryManager.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListProduct();
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Product product);
    }
}
