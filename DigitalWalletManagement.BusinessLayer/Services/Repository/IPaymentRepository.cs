using DigitalWalletManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWalletManagement.BusinessLayer.Services.Repository
{
    public interface IPaymentRepository
    {
        Task<Payment> SchedulePaymentAsync(int walletId, decimal amount, int recipientId, string frequency, DateTime startDate);

        Task<Payment> MakeInstantPaymentAsync(int walletId, decimal amount, int recipientId);
    }
}
