using DigitalWalletManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWalletManagement.BusinessLayer.Services.Repository
{
    public interface ISecurityRepository
    {
        Task<TwoFactorAuthenticationRequest> SetupTwoFactorAuthenticationAsync(int userId, string phoneNumber);

        Task<TwoFactorAuthenticationRequest> GetSecurityAuditLogAsync(int userId);
    }
}
