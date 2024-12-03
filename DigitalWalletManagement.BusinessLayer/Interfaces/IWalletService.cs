using DigitalWalletManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWalletManagement.BusinessLayer.Interfaces
{
    public interface IWalletService
    {
        Task<Wallet> AddAsync(Wallet wallet);
        Task<Wallet> GetByIdAsync(int walletId);
        Task<Wallet> UpdateAsync(Wallet wallet);
        Task<List<Wallet>> GetAll();
        Task<bool> DeleteAsync(int walletId);
    }
}
