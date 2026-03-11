using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Client;

namespace PerthLeadership.Infrastructure.Data.Configurations.Client;

public class OverAllUserConfiguration : IEntityTypeConfiguration<OverAllUser>
{
    public void Configure(EntityTypeBuilder<OverAllUser> builder)
    {
        builder.ToTable("tblOverAllUsers");

        builder.HasKey(e => e.Id);
        builder.HasAlternateKey(e => e.OverallUserId).HasName("AK_tblOverAllUsers_OverallUserId");

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
