using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;

namespace InventoryManager.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
     
        public async Task<List<Product>> GetProductsList()
        {
            return await _productRepository!.GetProductsListAsync();
        }

        public async Task<Product?> GetProduct(int id)
        {
            return await _productRepository!.GetProductAsync(id);
        }

        public async Task CreateProduct(Product product)
        {
            await _productRepository!.CreateProductAsync(product);
        }

        public async Task UpdateProduct(Product product)
        {
            await _productRepository!.UpdateProductAsync(product);
        }

        public async Task DeleteProduct(Product product)
        {
            await _productRepository!.DeleteProductAsync(product);
        }
    }
}
