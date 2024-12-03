using DigitalWalletManagement.BusinessLayer.Interfaces;
using DigitalWalletManagement.BusinessLayer.Services.Repository;
using DigitalWalletManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWalletManagement.BusinessLayer.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Payment> MakeInstantPaymentAsync(int walletId, decimal amount, int recipientId)
        {
            return await _paymentRepository.MakeInstantPaymentAsync(walletId,amount,recipientId);
        }

        public async Task<Payment> SchedulePaymentAsync(int walletId, decimal amount, int recipientId, string frequency, DateTime startDate)
        {
            return await _paymentRepository.SchedulePaymentAsync(walletId,amount,recipientId,frequency,startDate);
        }
    }
}
