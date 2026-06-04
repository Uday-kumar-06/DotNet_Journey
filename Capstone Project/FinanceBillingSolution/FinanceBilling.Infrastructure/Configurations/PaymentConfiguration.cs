using FinanceBilling.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceBilling.Infrastructure.Configurations;

public class PaymentConfiguration
    : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(x => x.PaymentId);

        builder.Property(x => x.AmountPaid)
            .HasPrecision(18, 2);

        builder.Property(x => x.PaymentMethod)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasOne(x => x.Invoice)
            .WithMany(x => x.Payments)
            .HasForeignKey(x => x.InvoiceId);
    }
}