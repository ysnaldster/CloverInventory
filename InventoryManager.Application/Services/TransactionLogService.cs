using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Application.Services
{
    internal class TransactionLogService : IGenericRestRepository<TransactionLog>
    {
        private readonly InventoryManagerContext _context;

        public TransactionLogService(InventoryManagerContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<TransactionLog>> ItemList()
        {
            return await _context.TransactionLogs
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
            var actualTransactionLog = await _context.TransactionLogs.SingleOrDefaultAsync(p => p.Id == transactionLog.Id);
            actualTransactionLog!.Quantity = transactionLog.Quantity;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(TransactionLog? transactionLog)
        {
            var transactionLogToDelete = await _context.TransactionLogs
                .Where(s => s.Id == transactionLog!.Id)
                .SingleOrDefaultAsync();
            _context.Remove(transactionLogToDelete!);
            await _context.SaveChangesAsync();
        }
    }
}
