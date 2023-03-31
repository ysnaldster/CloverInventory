using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Domain
{
    internal interface IGenericRestRepository<T>
    {
        Task<List<T>> ItemList();

        Task CreateItem(T? item);
        Task UpdateItem(T? item);
        Task DeleteItem(T? item);
    }
}
