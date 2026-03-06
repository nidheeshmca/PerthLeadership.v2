using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Client;

namespace PerthLeadership.Infrastructure.Data.Configurations.Client;

public class OverAllUserConfiguration : IEntityTypeConfiguration<OverAllUser>
{
    public void Configure(EntityTypeBuilder<OverAllUser> builder)
    {
        builder.ToTable("tblOverAllUsers");

        builder.HasKey(e => e.OverallUserId)
            .HasName("PK_tblOverAllUsers");

        builder.Property(e => e.OverallUserId)
            .HasColumnName("OverAllUserId")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.Email).HasMaxLength(200).IsUnicode(false).IsRequired();
        builder.Property(e => e.Password).HasMaxLength(20).IsUnicode(false).IsRequired();
        builder.Property(e => e.UserType).HasMaxLength(50).IsUnicode(false).IsRequired();
        builder.Property(e => e.UserName).HasMaxLength(200).IsUnicode(false);
        builder.Property(e => e.Role).HasMaxLength(50).IsUnicode(false);
    }
}
