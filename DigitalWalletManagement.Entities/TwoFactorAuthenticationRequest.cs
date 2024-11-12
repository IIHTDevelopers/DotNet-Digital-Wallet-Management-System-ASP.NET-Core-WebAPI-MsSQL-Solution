using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigitalWalletManagement.Entities
{
    public class TwoFactorAuthenticationRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthId { get; set; }
        public int UserId { get; set; }      
        public string PhoneNumber { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
