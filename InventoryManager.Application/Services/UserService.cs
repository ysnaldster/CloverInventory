using InventoryManager.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Application.Services
{
    public class UserService 
    {
        private readonly InventoryManagerContext? _inventoryManagerContext;

        public UserService(InventoryManagerContext inventoryManagerContext)
        {
            _inventoryManagerContext = inventoryManagerContext;
        }

        public bool IsUser(string username, string password)
        {
            return _inventoryManagerContext.Users.Where(p => p.Username == username && p.Password == password).Any();
        }
            
    }
}
