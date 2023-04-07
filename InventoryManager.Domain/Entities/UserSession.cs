using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Domain.Entities
{
    public class UserSession
    {
        public string? UserName { get; set; }
        public string? Role { get; set; }
    }
}
