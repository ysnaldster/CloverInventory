using System.Text.Json.Serialization;

namespace InventoryManager.Domain.Entities
{
    public class Product
    {
        public int? Id { get; set; }
        public int? CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int TotalQuantity { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Category? Category { get; set; }
        [JsonIgnore] public virtual ICollection<Storage>? Storages { get; set; }

        [JsonIgnore] public ICollection<ProductUserPivot>? ProductPivots { get; set; }

    }
}
