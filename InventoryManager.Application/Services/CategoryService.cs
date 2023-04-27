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
    public class CategoryService
    {
        private readonly IGenericRestRepository<Category>? _categoryRepository;

        public CategoryService(IGenericRestRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> ItemList()
        {
            return await _categoryRepository!.ItemList();
        }

        public async Task CreateItem(Category? category)
        {
            await _categoryRepository!.CreateItem(category);
        }

        public async Task UpdateItem(Category? category)
        {
            await _categoryRepository!.UpdateItem(category);
        }

        public async Task DeleteItem(Category? category)
        {
            await _categoryRepository!.DeleteItem(category);
        }
    }
}
