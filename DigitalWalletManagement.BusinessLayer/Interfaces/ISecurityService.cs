using DigitalWalletManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWalletManagement.BusinessLayer.Interfaces
{
    public interface ISecurityService
    {
        Task<TwoFactorAuthenticationRequest> SetupTwoFactorAuthenticationAsync(int userId,string phoneNumber);

        Task<TwoFactorAuthenticationRequest> GetSecurityAuditLogAsync(int userId);
    }
}
