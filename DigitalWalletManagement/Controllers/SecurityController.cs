using DigitalWalletManagement.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using DigitalWalletManagement.Entities;
using Microsoft.AspNetCore.Http;

namespace DigitalWalletManagement.Controllers
{
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpPost]
        [Route("api/security/two-factor/setup")]
        [AllowAnonymous]
        public async Task<IActionResult> SetupTwoFactorAuthenticationAsync(int userId, string phoneNumber)
        {
            var result = await _securityService.SetupTwoFactorAuthenticationAsync(userId, phoneNumber);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Operation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Two factor authentication successfull!" });
        }

        [HttpGet]
        [Route("api/security/audit")]
        public async Task<IActionResult> GetSecurityAuditLogAsync(int userId)
        {
            var auditLog = await _securityService.GetSecurityAuditLogAsync(userId);
            if (auditLog == null)
            {
               return NotFound($"No audit log found for user with ID {userId}.");
            }
            return Ok(auditLog);
        }
    }
}
