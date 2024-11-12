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
    public class SecurityRepository : ISecurityRepository
    {
        private readonly DigitalWalletDbContext _dbContext;
        public SecurityRepository(DigitalWalletDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TwoFactorAuthenticationRequest> GetSecurityAuditLogAsync(int userId)
        {
           
            try
            {
                var auditLogs = await _dbContext.TwoFactorAuthenticationRequests
                                            .Where(log => log.UserId == userId)
                                            .FirstOrDefaultAsync();

                return auditLogs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TwoFactorAuthenticationRequest> SetupTwoFactorAuthenticationAsync(int userId, string phoneNumber)
        {
            try
            {
                var existing2FA = await _dbContext.TwoFactorAuthenticationRequests
                                                  .FirstOrDefaultAsync(tfa => tfa.UserId == userId);


                var twoFactorRequest = new TwoFactorAuthenticationRequest
                {
                    UserId = userId,
                    PhoneNumber = phoneNumber,
                    IsEnabled = true,
                    CreatedDate = DateTime.UtcNow
                };

                await _dbContext.TwoFactorAuthenticationRequests.AddAsync(twoFactorRequest);
                await _dbContext.SaveChangesAsync();

                return twoFactorRequest;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
