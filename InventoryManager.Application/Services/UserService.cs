using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;
using InventoryManager.Infrastructure;
using InventoryManager.Infrastructure.Repositories;
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
        private readonly IGenericRestRepository<User>? _userRepository;
        private readonly UserRepository userRepositoryCustom;
        public UserService(IGenericRestRepository<User>? userRepository, UserRepository userRepositoryCustom)
        {
            _userRepository = userRepository;
            this.userRepositoryCustom = userRepositoryCustom;
        }

        public async Task<User?> GetUserByUserName(string? username)
        {
            return await userRepositoryCustom.GetUserByUserName(username);
        }
        public async Task CreateItem(User? user)
        {
            await _userRepository!.CreateItem(user);
        }
    }
}