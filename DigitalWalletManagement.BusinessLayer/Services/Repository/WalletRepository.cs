using DigitalWalletManagement.DataLayer;
using DigitalWalletManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWalletManagement.BusinessLayer.Services.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly DigitalWalletDbContext _dbContext;
        public WalletRepository(DigitalWalletDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Wallet> AddAsync(Wallet wallet)
        {
            try
            {
                await _dbContext.Wallets.AddAsync(wallet);  
                await _dbContext.SaveChangesAsync();

                return wallet; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(int walletId)
        {
            try
            {
                var existingWallet = await _dbContext.Wallets
                                                     .FirstOrDefaultAsync(w => w.WalletId == walletId);


                _dbContext.Wallets.Remove(existingWallet);
                await _dbContext.SaveChangesAsync();  

                return true;  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Wallet>> GetAll()
        {
            try
            {
                var wallet = await _dbContext.Wallets.ToListAsync();                                       

                return wallet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Wallet> GetByIdAsync(int walletId)
        {
            try
            {
                var wallet = await _dbContext.Wallets
                                             .FirstOrDefaultAsync(w => w.WalletId == walletId); 

                return wallet;  
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Wallet> UpdateAsync(Wallet wallet)
        {
            try
            {

                var existingWallet = await _dbContext.Wallets
                                                     .FirstOrDefaultAsync(w => w.WalletId == wallet.WalletId);

                _dbContext.Wallets.Update(existingWallet);  
                await _dbContext.SaveChangesAsync(); 

                return existingWallet; 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
