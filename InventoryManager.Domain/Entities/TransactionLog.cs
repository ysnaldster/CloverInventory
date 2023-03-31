using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Domain.Entities
{
    public class TransactionLog
    {
        public string Id { get; set; }
        public string StorageId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Quantity { get; set; }

        public bool IsInput { get; set; }

        public virtual Storage? Storage { get; set; }
    }
}
