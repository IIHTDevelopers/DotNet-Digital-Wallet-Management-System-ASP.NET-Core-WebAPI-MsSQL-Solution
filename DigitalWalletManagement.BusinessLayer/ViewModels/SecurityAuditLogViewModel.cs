using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWalletManagement.BusinessLayer.ViewModels
{
    public class SecurityAuditLogViewModel
    {
        public int LogId { get; set; }
        public int UserId { get; set; }
        public string EventType { get; set; }
        public string Details { get; set; }
        public DateTime Timestamp { get; set; }
        public string IpAddress { get; set; }
        public string DeviceInfo { get; set; }
    }
}
