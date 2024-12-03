using DigitalWalletManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWalletManagement.BusinessLayer.Services.Repository
{
    public interface IWalletRepository
    {
        Task<Wallet> AddAsync(Wallet wallet);
        Task<Wallet> GetByIdAsync(int walletId);
        Task<List<Wallet>> GetAll();
        Task<Wallet> UpdateAsync(Wallet wallet);
        Task<bool> DeleteAsync(int walletId);
    }
}
