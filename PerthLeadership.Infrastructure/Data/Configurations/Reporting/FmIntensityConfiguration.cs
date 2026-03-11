using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Reporting;

namespace PerthLeadership.Infrastructure.Data.Configurations.Reporting;

public class FmIntensityConfiguration : IEntityTypeConfiguration<FmIntensity>
{
    public void Configure(EntityTypeBuilder<FmIntensity> builder)
    {
        builder.ToTable("tblFmIntensity");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.VaId).HasColumnName("vaId");
        builder.Property(e => e.RuId).HasColumnName("ruId");
        builder.Property(e => e.Mode).HasColumnName("mode").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.IndexRU).HasColumnName("indexRU");
        builder.Property(e => e.IndexVA).HasColumnName("indexVA");
        builder.Property(e => e.FMIntensityValue).HasColumnName("FMIntensity").HasMaxLength(50).IsUnicode(false);
    }
}
