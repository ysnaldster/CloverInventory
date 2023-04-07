using InventoryManager.Domain.Entities;
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

        public List<User> users = new List<User>
        {
            new()
            {
                UserName = "admin",
                Password = "admin",
                Role = "Administrator"
            },
            new()
            {
                UserName = "user",
                Password = "user",
                Role = "User"
            }
        };
        
        public User? GetUserByUserName(string? username)
        {
            return _inventoryManagerContext.Users.FirstOrDefault(p => p.UserName == username);   
        } 
            
    }
}