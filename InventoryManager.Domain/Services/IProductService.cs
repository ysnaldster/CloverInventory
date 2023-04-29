using InventoryManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Domain.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task PostProductAsync(Product product);
        Task DeleteProductAsync(Product product);
        Task PutProductAsync(Product product);
    }
}
