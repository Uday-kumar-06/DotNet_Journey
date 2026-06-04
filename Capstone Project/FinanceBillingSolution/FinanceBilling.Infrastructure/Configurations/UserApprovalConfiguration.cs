using FinanceBilling.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceBilling.Infrastructure.Configurations;

public class UserApprovalConfiguration
    : IEntityTypeConfiguration<UserApproval>
{
    public void Configure(EntityTypeBuilder<UserApproval> builder)
    {
        builder.HasKey(x => x.ApprovalId);

        builder.Property(x => x.Remarks)
            .HasMaxLength(500);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ApprovedByUser)
            .WithMany()
            .HasForeignKey(x => x.ApprovedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.AssignedRole)
            .WithMany()
            .HasForeignKey(x => x.AssignedRoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}