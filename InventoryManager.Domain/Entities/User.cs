using System.Text.Json.Serialization;

namespace InventoryManager.Domain.Entities
{
    public class User
    {
        public int? Id { get; set; }
        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? Role { get; set; }

        public string? Email { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

        [JsonIgnore] public virtual ICollection<ProductUserPivot>? UserPivots { get; set; } 
    }
}
