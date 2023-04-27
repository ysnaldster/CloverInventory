using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Infrastructure.Repositories
{
    public class StorageRepository : IGenericRestRepository<Storage>
    {
        private static InventoryManagerContext? _context;

        public StorageRepository(InventoryManagerContext? dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Storage>> ItemList()
        {
            return await _context!.Storages!
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task CreateItem(Storage? storage)
        {
            if (storage == null) throw new ArgumentNullException(nameof(storage));
            await _context!.AddAsync(storage);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(Storage? storage)
        {
            if (storage == null) throw new ArgumentNullException(nameof(storage));
            var actualStore = await _context!.Storages!.SingleOrDefaultAsync(p => p.Id == storage.Id);
            actualStore!.PartialQuantity = storage.PartialQuantity;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(Storage? storage)
        {
            var storageToDelete = await _context!.Storages!
                .Where(s => s.Id == storage!.Id)
                .SingleOrDefaultAsync();
            _context.Remove(storageToDelete!);
            await _context.SaveChangesAsync();
        }

        public bool IsProductWarehouse(string idStorage)
        {
            var validate = _context!.Storages!.ToList().Where(p => p.Id.ToString() == idStorage);
            return validate.Any();
        }

        public async Task<List<Storage>> StorageProductsByWarehouse(int warehouseId)
        {
            return await _context!.Storages!
                .Include(s => s.Product)
                .Include(s => s.Warehouse)
                .Where(s => s.WarehouseId == warehouseId)
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<Storage> Item(int id)
        {
            throw new NotImplementedException();
        }
    }
}
