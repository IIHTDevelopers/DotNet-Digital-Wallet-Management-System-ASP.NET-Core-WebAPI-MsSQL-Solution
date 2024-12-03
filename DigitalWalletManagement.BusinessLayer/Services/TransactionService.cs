using DigitalWalletManagement.BusinessLayer.Interfaces;
using DigitalWalletManagement.BusinessLayer.Services.Repository;
using DigitalWalletManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWalletManagement.BusinessLayer.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Transaction> AddTransactionAsync(Transaction transaction)
        {
            return await _transactionRepository.AddTransactionAsync(transaction);
        }

        public async Task<Transaction> GetTransactionDetailAsync(int transactionId)
        {
            return await _transactionRepository.GetTransactionDetailAsync(transactionId);
        }

        public async Task<List<Transaction>> GetTransactionHistoryAsync(int walletId, DateTime startDate, DateTime endDate, string transactionType = null)
        {
            return await _transactionRepository.GetTransactionHistoryAsync(walletId,startDate,endDate,transactionType);
        }
    }
}
