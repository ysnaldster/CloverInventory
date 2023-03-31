using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InventoryManager.Domain.Entities
{
    public class Warehouse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        [JsonIgnore] public virtual ICollection<Storage>? Storages { get; set; }
    }
}
