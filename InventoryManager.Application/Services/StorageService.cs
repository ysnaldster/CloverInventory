using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;
using InventoryManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Application.Services
{
    public class StorageService
    {
        private readonly IGenericRestRepository<Storage>? _storageRepository;
        private readonly StorageRepository _storageRepositoryCustom;

        public StorageService(IGenericRestRepository<Storage> storageRepository, StorageRepository storageRepositoryCustom)
        {
            _storageRepository = storageRepository;
            _storageRepositoryCustom = storageRepositoryCustom;
        }

        public async Task<List<Storage>> ItemList()
        {
            return await _storageRepository!.ItemList();
        }

        public async Task CreateItem(Storage? storage)
        {
            await _storageRepository!.CreateItem(storage);
        }

        public async Task UpdateItem(Storage? storage)
        {
            await _storageRepository!.UpdateItem(storage);
        }

        public async Task DeleteItem(Storage? storage)
        {
            await _storageRepository!.DeleteItem(storage);
        }

        public bool IsProductWarehouse(string idStorage)
        {
            return _storageRepositoryCustom.IsProductWarehouse(idStorage);
        }

        public async Task<List<Storage>> StorageProductsByWarehouse(int warehouseId)
        {
            return await _storageRepositoryCustom.StorageProductsByWarehouse(warehouseId);
        }
    }
}
