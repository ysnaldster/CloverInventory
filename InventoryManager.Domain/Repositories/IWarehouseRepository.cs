using InventoryManager.Domain.Entities;

namespace InventoryManager.Domain.Repositories
{
    public interface IWarehouseRepository
    {
        Task<List<Warehouse>> GetWarehousesListAsync();
    }
}
