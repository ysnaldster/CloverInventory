using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InventoryManager.Domain
{
    internal class Product
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalQuantity { get; set; }
        public DateTime CreationDate { get; set; }

        //Relations

        public virtual Category? Category { get; set; }
        [JsonIgnore] public virtual ICollection<Storage>? Storages { get; set; }

    }
}
