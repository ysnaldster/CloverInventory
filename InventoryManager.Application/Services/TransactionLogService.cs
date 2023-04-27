using InventoryManager.Domain.Entities;
using InventoryManager.Domain.Repositories;
using InventoryManager.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Application.Services
{
    public class TransactionLogService
    {
        private readonly IGenericRestRepository<TransactionLog>? _transactionLogRepository;

        public TransactionLogService(IGenericRestRepository<TransactionLog> transactionLogRepository)
        {
            _transactionLogRepository = transactionLogRepository;
        }

        public async Task<List<TransactionLog>> ItemList()
        {
            return await _transactionLogRepository!.ItemList();
        }

        public async Task CreateItem(TransactionLog? transactionLog)
        {
            await _transactionLogRepository!.CreateItem(transactionLog);
        }

        public async Task UpdateItem(TransactionLog? transactionLog)
        {
            await _transactionLogRepository!.UpdateItem(transactionLog);
        }

        public async Task DeleteItem(TransactionLog? transactionLog)
        {
            await _transactionLogRepository!.DeleteItem(transactionLog);
        }

    }
}
