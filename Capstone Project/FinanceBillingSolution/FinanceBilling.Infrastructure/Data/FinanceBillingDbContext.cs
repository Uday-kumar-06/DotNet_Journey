using FinanceBilling.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Infrastructure.Data
{
    public class FinanceBillingDbContext : DbContext
    {
        public FinanceBillingDbContext(
            DbContextOptions<FinanceBillingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Roles => Set<Role>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserApproval> UserApprovals => Set<UserApproval>();
        public DbSet<Invoice> Invoices => Set<Invoice>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(FinanceBillingDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
