using DigitalWalletManagement.DataLayer;
using DigitalWalletManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWalletManagement.BusinessLayer.Services.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DigitalWalletDbContext _dbContext;
        public PaymentRepository(DigitalWalletDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Payment> MakeInstantPaymentAsync(int walletId, decimal amount, int recipientId)
        {
            try
            {

                var payment = new Payment
                {
                    WalletId = walletId,
                    Amount = amount,
                    RecipientId = recipientId,
                    Frequency = "One-time",
                    StartDate = DateTime.UtcNow,
                };

                await _dbContext.Payments.AddAsync(payment);

                await _dbContext.SaveChangesAsync();

                return payment;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Payment> SchedulePaymentAsync(int walletId, decimal amount, int recipientId, string frequency, DateTime startDate)
        {
            try
            {
                var payment = new Payment
                {
                    WalletId = walletId,
                    Amount = amount,
                    RecipientId = recipientId,
                    Frequency = frequency,
                    StartDate = startDate,
                };

                await _dbContext.Payments.AddAsync(payment);

                await _dbContext.SaveChangesAsync();

                return payment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
