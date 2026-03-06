using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Admin;

namespace PerthLeadership.Infrastructure.Data.Configurations.Admin;

public class AdminLogConfiguration : IEntityTypeConfiguration<AdminLog>
{
    public void Configure(EntityTypeBuilder<AdminLog> builder)
    {
        builder.ToTable("AdminLog");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.LogDate).HasColumnName("TDate");
        builder.Property(e => e.AdminName).HasColumnName("Admin").HasMaxLength(50);
    }
}
