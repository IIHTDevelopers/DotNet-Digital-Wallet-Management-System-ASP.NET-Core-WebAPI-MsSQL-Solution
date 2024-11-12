using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DigitalWalletManagement.Entities
{
    public class SecurityAuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogId { get; set; }  
        public int UserId { get; set; } 
        public string EventType { get; set; }
        public string Details { get; set; }
        public DateTime Timestamp { get; set; }
        public string IpAddress { get; set; }
        public string DeviceInfo { get; set; }
    }
}
