using DigitalWalletManagement.BusinessLayer.Interfaces;
using DigitalWalletManagement.BusinessLayer.Services;
using DigitalWalletManagement.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DigitalWalletManagement.Controllers
{
   
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService walletService)
        {
            _transactionService = walletService;
        }

        [HttpGet]
        [Route("/api/transaction/history")]
        [AllowAnonymous]
        public async Task<IActionResult> RetrieveTransactionHistory([FromQuery] int walletId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] string transactionType)
        {
            var result = await _transactionService.GetTransactionHistoryAsync(walletId, startDate, endDate, transactionType);
            return Ok(result);
        }

        [HttpGet]
        [Route("/api/transaction/{transactionId}")]
        [AllowAnonymous]
        public async Task<IActionResult> RetrieveTransactionDetails(int transactionId)
        {
            var result = await _transactionService.GetTransactionDetailAsync(transactionId);
            return Ok(result);
        }

        [HttpPost]
        [Route("/api/transaction/create-transaction")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateTransaction([FromBody] Transaction model)
        {
            var result = await _transactionService.AddTransactionAsync(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Operation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Transaction id created successfully!" });
        }
    }
}
