using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InventoryManager.Domain.Entities
{
    public class Storage
    {
        public string? Id { get; set; }
        public string? ProductId { get; set; }
        public string? WarehouseId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? PartialQuantity { get; set; }

        public virtual Warehouse? Warehouse { get; set; }
        public virtual Product? Product { get; set; }

        [JsonIgnore] public virtual ICollection<TransactionLog>? TransactionLogs { get; set; }
    }
}
