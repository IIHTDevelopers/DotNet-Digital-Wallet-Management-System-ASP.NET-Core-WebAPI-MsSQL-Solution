using DigitalWalletManagement.BusinessLayer.Interfaces;
using DigitalWalletManagement.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DigitalWalletManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;
        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpPost]
        [Route("/api/wallet/create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateWallet([FromBody] Wallet model)
        {
            var walletExists = await _walletService.GetByIdAsync(model.WalletId);
            if (walletExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Wallet id already exists!" });
            var result = await _walletService.AddAsync(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Wallet id creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Wallet id created successfully!" });

        }

        [HttpGet]
        [Route("/api/wallet/{walletId}")]
        [AllowAnonymous]
        public async Task<IActionResult> RetrieveWallet(int walletId)
        {
            var walletExists = await _walletService.GetByIdAsync(walletId);
            if (walletExists == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Wallet With Id = {walletId} cannot be found" });
            }
            else
            {
                return Ok(walletExists);
            }
        }

        [HttpGet]
        [Route("/api/wallet/get-all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllWalletDetails()
        {
            var walletExists = await _walletService.GetAll();
            return Ok(walletExists);
        }

        [HttpPut]
        [Route("/api/wallet/update/{walletId}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateWallet(int walletId,Wallet model)
        {
            var walletExists = await _walletService.GetByIdAsync(walletId);
            if (walletExists == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Wallet With Id = {walletId} cannot be found" });
            }
            else
            {
                var result = await _walletService.UpdateAsync(model);
                return Ok(new Response { Status = "Success", Message = "Wallet updated successfully!" });
            }
        }

        [HttpDelete]
        [Route("/api/wallet/delete/{walletId}")]
        public async Task<IActionResult> DeleteWallet(int walletId)
        {
            var walletExists = await _walletService.GetByIdAsync(walletId);
            if (walletExists == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Wallet With Id = {walletId} cannot be found" });
            }
            else
            {
                var result = await _walletService.DeleteAsync(walletId);
                return Ok(new Response { Status = "Success", Message = "Wallet id deleted successfully!" });
            }
        }
    }
}
