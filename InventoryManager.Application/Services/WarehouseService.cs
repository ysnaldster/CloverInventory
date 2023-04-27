using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Application.Services
{
    public class WarehouseService
    {
        private readonly IGenericRestRepository<Warehouse>? _warehouseRepository;

        public WarehouseService(IGenericRestRepository<Warehouse> warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<List<Warehouse>> ItemList()
        {
            return await _warehouseRepository!.ItemList();
        }

        public async Task CreateItem(Warehouse? warehouse)
        {
            await _warehouseRepository!.CreateItem(warehouse);
        }

        public async Task UpdateItem(Warehouse? warehouse)
        {
            await _warehouseRepository!.UpdateItem(warehouse);
        }

        public async Task DeleteItem(Warehouse? warehouse)
        {
            await _warehouseRepository!.DeleteItem(warehouse);
        }
    }
}
