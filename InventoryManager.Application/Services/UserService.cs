using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;

namespace InventoryManager.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;           
        }

        public async Task<User?> GetUserByUserName(string username)
        {
            return await _userRepository.GetUserByUserNameAsync(username);
        }
        public async Task CreateUser(User user)
        {
            await _userRepository!.CreateUserAsync(user);
        }
    }
}