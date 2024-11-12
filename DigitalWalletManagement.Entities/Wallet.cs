using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigitalWalletManagement.Entities
{
    public class Wallet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WalletId { get; set; } 
        public int UserId { get; set; } 
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; } 
        public string Name { get; set; }
    }
}
