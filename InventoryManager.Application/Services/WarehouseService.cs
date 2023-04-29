using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;

namespace InventoryManager.Application.Services
{
    public class WarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<List<Warehouse>> GetWarehouseList()
        {
            return await _warehouseRepository!.GetWarehousesListAsync();
        }
    }
}
