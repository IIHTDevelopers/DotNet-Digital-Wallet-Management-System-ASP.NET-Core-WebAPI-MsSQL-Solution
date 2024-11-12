using DigitalWalletManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWalletManagement.BusinessLayer.Interfaces
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetTransactionHistoryAsync(int walletId,DateTime startDate,DateTime endDate,string transactionType = null);

        Task<Transaction> GetTransactionDetailAsync(int transactionId);

        Task<Transaction> AddTransactionAsync(Transaction transaction);
    }
}
