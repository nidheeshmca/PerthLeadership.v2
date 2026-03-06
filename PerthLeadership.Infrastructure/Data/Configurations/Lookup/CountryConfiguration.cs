using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Lookup;

namespace PerthLeadership.Infrastructure.Data.Configurations.Lookup;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("country");

        builder.HasKey(e => e.CountryId);

        builder.Property(e => e.CountryId)
            .HasColumnName("CountryID")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.CountryName).HasMaxLength(150);
        builder.Property(e => e.CountryCode).HasMaxLength(3);
        builder.Property(e => e.RegionId).HasColumnName("RegionID");
    }
}
