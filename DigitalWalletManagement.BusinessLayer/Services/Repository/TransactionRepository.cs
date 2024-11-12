using DigitalWalletManagement.DataLayer;
using DigitalWalletManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWalletManagement.BusinessLayer.Services.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DigitalWalletDbContext _dbContext;
        public TransactionRepository(DigitalWalletDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Transaction> AddTransactionAsync(Transaction transaction)
        {
            try
            {
                await _dbContext.Transactions.AddAsync(transaction);
                await _dbContext.SaveChangesAsync();

                return transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Transaction> GetTransactionDetailAsync(int transactionId)
        {
            try
            {
                var transaction = await _dbContext.Transactions
                                                   .Where(t => t.TransactionId == transactionId)
                                                   .FirstOrDefaultAsync();
                return transaction;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Transaction>> GetTransactionHistoryAsync(int walletId, DateTime startDate, DateTime endDate, string transactionType = null)
        {
            try
            {
                var query = await _dbContext.Transactions
                                      .Where(t => t.WalletId == walletId && t.Date >= startDate && t.Date <= endDate).ToListAsync();

                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
