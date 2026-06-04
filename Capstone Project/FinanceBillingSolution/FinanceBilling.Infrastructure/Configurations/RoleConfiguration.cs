using FinanceBilling.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceBilling.Infrastructure.Configurations;

public class RoleConfiguration
    : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.RoleId);

        builder.Property(x => x.RoleName)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(x => x.RoleName)
            .IsUnique();
        builder.HasData(
                new Role
                {
                    RoleId = 1,
                    RoleName = "Admin"
                },
                new Role
                {
                    RoleId = 2,
                    RoleName = "Manager"
                },
                new Role
                {
                    RoleId = 3,
                    RoleName = "Client"
                }
        );
    }
}