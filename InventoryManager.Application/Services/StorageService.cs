using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Application.Services
{
    internal class StorageService : IGenericRestRepository<Storage>
    {
        private static InventoryManagerContext _context;

        public StorageService(InventoryManagerContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Storage>> ItemList()
        {
            return await _context.Storages
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task CreateItem(Storage? storage)
        {
            if (storage == null) throw new ArgumentNullException(nameof(storage));
            await _context.AddAsync(storage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(Storage? storage)
        {
            if (storage == null) throw new ArgumentNullException(nameof(storage));
            var actualStore = await _context.Storages.SingleOrDefaultAsync(p => p.Id == storage.Id);
            actualStore!.PartialQuantity = storage.PartialQuantity;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(Storage? storage)
        {
            var storageToDelete = await _context.Storages
                .Where(s => s.Id == storage!.Id)
                .SingleOrDefaultAsync();
            _context.Remove(storageToDelete!);
            await _context.SaveChangesAsync();
        }

        public static bool IsProductWarehouse(string idStorage)
        {
            var validate = _context.Storages.ToList().Where(p => p.Id == idStorage);
            return validate.Any();
        }

        public async Task<List<Storage>> StorageProductsByWarehouse(string warehouseId)
        {
            return await _context.Storages
                .Include(s => s.Product)
                .Include(s => s.Warehouse)
                .Where(s => s.WarehouseId == warehouseId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
