using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWalletManagement.BusinessLayer.ViewModels
{
    public class WalletViewModel
    {
        public int WalletId { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
    }
}
