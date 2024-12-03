using DigitalWalletManagement.BusinessLayer.Interfaces;
using DigitalWalletManagement.BusinessLayer.Services.Repository;
using DigitalWalletManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWalletManagement.BusinessLayer.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<Wallet> AddAsync(Wallet wallet)
        {
            return await _walletRepository.AddAsync(wallet);
        }

        public async Task<bool> DeleteAsync(int walletId)
        {
            return await _walletRepository.DeleteAsync(walletId);
        }

        public async Task<List<Wallet>> GetAll()
        {
            return await _walletRepository.GetAll();
        }

        public async Task<Wallet> GetByIdAsync(int walletId)
        {
            return await _walletRepository.GetByIdAsync(walletId);
        }

        public async Task<Wallet> UpdateAsync(Wallet wallet)
        {
            return await _walletRepository.UpdateAsync(wallet);
        }
    }
}
