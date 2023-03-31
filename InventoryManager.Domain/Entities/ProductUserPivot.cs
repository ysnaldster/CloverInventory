using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Domain.Entities
{
    public class ProductUserPivot
    {
        public string? Id { get; set; }
        public string? ProductId { get; set; }
        public string? UserId { get; set; }

        public virtual User? User { get; set; }

        public virtual Product? Product { get; set; }
    }
}
