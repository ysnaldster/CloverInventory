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
    public class WarehouseRepository : IGenericRestRepository<Warehouse>
    {
        private readonly InventoryManagerContext? _context;

        public WarehouseRepository(InventoryManagerContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Warehouse>> ItemList()
        {
            return await _context!.Warehouses!
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task CreateItem(Warehouse? warehouse)
        {
            if (warehouse == null) throw new ArgumentNullException(nameof(warehouse));
            await _context!.AddAsync(warehouse);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(Warehouse? warehouse)
        {
            if (warehouse == null) throw new ArgumentNullException(nameof(warehouse));
            var actualWarehouse = await _context!.Warehouses!.SingleOrDefaultAsync(p => p.Id == warehouse.Id);
            actualWarehouse!.Name = warehouse.Name;
            actualWarehouse!.Address = warehouse.Address;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(Warehouse? warehouse)
        {
            var warehouseToDelete = await _context!.Warehouses!
                .Where(s => s.Id == warehouse!.Id)
                .SingleOrDefaultAsync();
            _context.Remove(warehouseToDelete!);
            await _context.SaveChangesAsync();
        }

        public Task<Warehouse> Item(int id)
        {
            throw new NotImplementedException();
        }
    }
}
