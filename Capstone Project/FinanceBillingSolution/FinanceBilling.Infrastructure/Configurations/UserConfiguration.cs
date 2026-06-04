using FinanceBilling.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceBilling.Infrastructure.Configurations;

public class UserConfiguration
    : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.UserId);

        builder.Property(x => x.Username)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Email)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.PasswordHash)
            .HasMaxLength(500)
            .IsRequired();

        builder.HasIndex(x => x.Username)
            .IsUnique();

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.HasOne(x => x.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
                new User
                {
                    UserId = 1,
                    Username = "admin",
                    Email = "admin@financebilling.com",
                    PasswordHash = "$2a$11$Qee9OEZPJufoclI.3.Bjc.RehRX3mE/5HdnOmOIdEakPl9Amr/Tvq",

                    RoleId = 1,

                    IsApproved = true,

                    IsActive = true,

                    CreatedAt = new DateTime(
                        2025,
                        1,
                        1,
                        0,
                        0,
                        0,
                        DateTimeKind.Utc)
                }
        );
    }
}