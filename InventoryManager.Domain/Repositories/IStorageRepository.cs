using InventoryManager.Domain.Entities;

namespace InventoryManager.Domain.Repositories
{
    public interface IStorageRepository
    {
        Task<List<Storage>> GetStoragesProductsByWarehouseListAsync(int warehouseId);
        Task CreateStorageAsync(Storage storage);
        Task UpdateStorageAsync(Storage storage);
        Task DeleteStorageAsync(Storage storage);

        bool ValidateProductIntoWarehouse(string storageId);

    }
}
