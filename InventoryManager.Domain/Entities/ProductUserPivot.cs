namespace InventoryManager.Domain.Entities
{
    public class ProductUserPivot
    {
        public int? Id { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }

        public virtual Product? Product { get; set; }
    }
}
