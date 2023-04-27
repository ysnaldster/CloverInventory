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
    public class TransactionLogRepository : IGenericRestRepository<TransactionLog>
    {
        private readonly InventoryManagerContext _context;

        public TransactionLogRepository(InventoryManagerContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<TransactionLog>> ItemList()
        {
            return await _context!.TransactionLogs!
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task CreateItem(TransactionLog? transactionLog)
        {
            if (transactionLog == null) throw new ArgumentNullException(nameof(transactionLog));
            await _context.AddAsync(transactionLog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(TransactionLog? transactionLog)
        {
            if (transactionLog == null) throw new ArgumentNullException(nameof(transactionLog));
            var actualTransactionLog = await _context!.TransactionLogs!.SingleOrDefaultAsync(p => p.Id == transactionLog.Id);
            actualTransactionLog!.Quantity = transactionLog.Quantity;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(TransactionLog? transactionLog)
        {
            var transactionLogToDelete = await _context!.TransactionLogs!
                .Where(s => s.Id == transactionLog!.Id)
                .SingleOrDefaultAsync();
            _context.Remove(transactionLogToDelete!);
            await _context.SaveChangesAsync();
        }

        public Task<TransactionLog> Item(int id)
        {
            throw new NotImplementedException();
        }
    }
}
