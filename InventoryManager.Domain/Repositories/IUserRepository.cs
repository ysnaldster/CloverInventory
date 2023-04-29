using InventoryManager.Domain.Entities;

namespace InventoryManager.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByUserNameAsync(string userName);
        Task CreateUserAsync(User user);
    }
}
