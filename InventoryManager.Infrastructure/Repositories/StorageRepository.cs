using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Infrastructure.Repositories
{
    public class StorageRepository : IStorageRepository
    {
        private static InventoryManagerContext? _context;

        public StorageRepository(InventoryManagerContext? dbContext)
        {
            _context = dbContext;
        }

        public bool ValidateProductIntoWarehouse(string storageId)
        {
            var validate = _context!.Storages!.ToList().Where(p => p.Id.ToString() == storageId);
            return validate.Any();
        }

        public async Task<List<Storage>> GetStoragesProductsByWarehouseListAsync(int warehouseId)
        {
            return await _context!.Storages!
                .Include(s => s.Product)
                .Include(s => s.Warehouse)
                .Where(s => s.WarehouseId == warehouseId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Storage>> GetStoragesListAsync()
        {
            return await _context!.Storages!
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task CreateStorageAsync(Storage storage)
        {
            if (storage == null) throw new ArgumentNullException(nameof(storage));
            await _context!.AddAsync(storage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStorageAsync(Storage storage)
        {
            if (storage == null) throw new ArgumentNullException(nameof(storage));
            var actualStore = await _context!.Storages!.SingleOrDefaultAsync(p => p.Id == storage.Id);
            actualStore!.PartialQuantity = storage.PartialQuantity;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStorageAsync(Storage storage)
        {
            var storageToDelete = await _context!.Storages!
               .Where(s => s.Id == storage!.Id)
               .SingleOrDefaultAsync();
            _context.Remove(storageToDelete!);
            await _context.SaveChangesAsync();
        }
    }
}
