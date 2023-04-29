using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly InventoryManagerContext? _context;

        public UserRepository(InventoryManagerContext inventoryManagerContext)
        {
            _context = inventoryManagerContext;
        }

        public async Task<User?> GetUserByUserNameAsync(string userName)
        {
            return await _context!.Users!.FirstOrDefaultAsync(p => p.UserName == userName);
        }

        public async Task CreateUserAsync(User user)
        {
            Random rnd = new Random();
            if (user == null) throw new ArgumentNullException(nameof(user));
            user.Id = rnd.Next(10000);
            user.Role = "User";
            await _context!.AddAsync(user);
            await _context.SaveChangesAsync();
        }    
    }
}
