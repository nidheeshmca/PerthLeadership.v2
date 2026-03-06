using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Client;

namespace PerthLeadership.Infrastructure.Data.Configurations.Client;

public class LicenseeConfiguration : IEntityTypeConfiguration<Licensee>
{
    public void Configure(EntityTypeBuilder<Licensee> builder)
    {
        builder.ToTable("tblLicensee");

        builder.HasKey(e => e.LicenseeId);

        builder.Property(e => e.LicenseeId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.LicenseeName).HasMaxLength(50).IsUnicode(false);
    }
}
