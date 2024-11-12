using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWalletManagement.BusinessLayer.ViewModels
{
    public class TransactionViewModel
    {
        public int TransactionId { get; set; }
        public int WalletId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
