using System.Text.Json.Serialization;

namespace InventoryManager.Domain.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        [JsonIgnore] public virtual ICollection<Storage>? Storages { get; set; }
    }
}
