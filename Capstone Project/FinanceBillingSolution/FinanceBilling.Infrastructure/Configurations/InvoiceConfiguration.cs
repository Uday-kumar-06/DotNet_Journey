using FinanceBilling.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceBilling.Infrastructure.Configurations;

public class InvoiceConfiguration
    : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasKey(x => x.InvoiceId);

        builder.Property(x => x.TotalAmount)
            .HasPrecision(18, 2);

        builder.HasOne(x => x.ClientUser)
            .WithMany(x => x.ClientInvoices)
            .HasForeignKey(x => x.ClientUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.CreatedByManager)
            .WithMany(x => x.ManagedInvoices)
            .HasForeignKey(x => x.CreatedByManagerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}