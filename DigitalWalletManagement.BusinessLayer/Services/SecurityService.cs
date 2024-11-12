using DigitalWalletManagement.BusinessLayer.Interfaces;
using DigitalWalletManagement.BusinessLayer.Services.Repository;
using DigitalWalletManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWalletManagement.BusinessLayer.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ISecurityRepository _securityRepository;

        public SecurityService(ISecurityRepository securityRepository)
        {
            _securityRepository = securityRepository;
        }

        public async Task<TwoFactorAuthenticationRequest> GetSecurityAuditLogAsync(int userId)
        {
            return await _securityRepository.GetSecurityAuditLogAsync(userId);
        }

        public async Task<TwoFactorAuthenticationRequest> SetupTwoFactorAuthenticationAsync(int userId, string phoneNumber)
        {
            return await _securityRepository.SetupTwoFactorAuthenticationAsync(userId,phoneNumber);
        }
    }
}
