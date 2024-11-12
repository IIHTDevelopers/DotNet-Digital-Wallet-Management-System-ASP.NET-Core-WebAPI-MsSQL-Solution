using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigitalWalletManagement.Entities
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; } 
        public int WalletId { get; set; } 
        public decimal Amount { get; set; }
        public string Type { get; set; } 
        public DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
