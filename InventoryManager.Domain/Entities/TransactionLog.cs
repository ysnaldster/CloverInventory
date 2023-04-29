namespace InventoryManager.Domain.Entities
{
    public class TransactionLog
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Quantity { get; set; }

        public bool IsInput { get; set; }

        public virtual Storage? Storage { get; set; }
    }
}
