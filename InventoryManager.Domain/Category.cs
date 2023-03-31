using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InventoryManager.Domain
{
    internal class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore] public virtual ICollection<Product>? Products { get; set; }
    }
}
