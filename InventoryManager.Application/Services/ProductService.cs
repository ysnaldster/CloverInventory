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
    public class ProductService
    {
        private readonly IGenericRestRepository<Product>? _productRepository;

        public ProductService(IGenericRestRepository<Product>? productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductService() { }

     
        public async Task<List<Product>> ItemList()
        {
            return await _productRepository!.ItemList();
        }

        public async Task<Product> Item(int id)
        {
            return await _productRepository!.Item(id);
        }

        public async Task CreateItem(Product? product)
        {
            await _productRepository!.CreateItem(product);
        }

        public async Task UpdateItem(Product? product)
        {
            await _productRepository!.UpdateItem(product);
        }

        public async Task DeleteItem(Product? product)
        {
            await _productRepository!.DeleteItem(product);
        }
    }
}
