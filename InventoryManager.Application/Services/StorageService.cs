using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;

namespace InventoryManager.Application.Services
{
    public class StorageService
    {
        private readonly IStorageRepository _storageRepository;

        public StorageService(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }

        public async Task CreateStorage(Storage storage)
        {
            await _storageRepository!.CreateStorageAsync(storage);
        }

        public async Task UpdateStorage(Storage storage)
        {
            await _storageRepository!.UpdateStorageAsync(storage);
        }

        public bool IsProductWarehouse(string idStorage)
        {
            return _storageRepository.ValidateProductIntoWarehouse(idStorage);
        }

        public async Task<List<Storage>> StorageProductsByWarehouse(int warehouseId)
        {
            return await _storageRepository.GetStoragesProductsByWarehouseListAsync(warehouseId);
        }
    }
}
