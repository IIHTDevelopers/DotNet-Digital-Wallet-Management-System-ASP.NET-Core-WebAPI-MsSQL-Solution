using DigitalWalletManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWalletManagement.DataLayer
{
    public class DigitalWalletDbContext : DbContext
    {
        public DigitalWalletDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<TwoFactorAuthenticationRequest> TwoFactorAuthenticationRequests { get; set; }
        public DbSet<SecurityAuditLog> SecurityAuditLogs { get; set; }

    }
}