using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWalletManagement.BusinessLayer.ViewModels
{
    public class TwoFactorAuthenticationRequestViewModel
    {
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
