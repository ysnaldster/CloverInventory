using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Infrastructure.Repositories
{
    public class UserRepository : IGenericRestRepository<User>
    {
        private readonly InventoryManagerContext? _context;

        public UserRepository(InventoryManagerContext inventoryManagerContext)
        {
            _context = inventoryManagerContext;
        }

        public async Task<User?> GetUserByUserName(string? username)
        {
            return await _context!.Users!.FirstOrDefaultAsync(p => p.UserName == username);
        }

        public async Task<List<User>> ItemList()
        {
            throw new NotImplementedException();
        }

        public async Task CreateItem(User? user)
        {
            Random rnd = new Random();
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.Id = rnd.Next(10000);
            user.Role = "User";
            await _context!.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(User? user)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateItem(User? user)
        {
            throw new NotImplementedException();
        }

        public Task<User> Item(int id)
        {
            throw new NotImplementedException();
        }
    }
}
