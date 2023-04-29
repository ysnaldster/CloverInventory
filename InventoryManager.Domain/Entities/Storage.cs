using System.Text.Json.Serialization;

namespace InventoryManager.Domain.Entities
{
    public class Storage
    {
        public int? Id { get; set; }
        public int? ProductId { get; set; }
        public int? WarehouseId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? PartialQuantity { get; set; }

        public virtual Warehouse? Warehouse { get; set; }
        public virtual Product? Product { get; set; }

        [JsonIgnore] public virtual ICollection<TransactionLog>? TransactionLogs { get; set; }
    }
}
