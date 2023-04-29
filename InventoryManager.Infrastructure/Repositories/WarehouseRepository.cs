using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Infrastructure.Repositories
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly InventoryManagerContext? _context;

        public WarehouseRepository(InventoryManagerContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Warehouse>> GetWarehousesListAsync()
        {
            return await _context!.Warehouses!
               .AsNoTracking()
               .ToListAsync();
        }
    }
}
