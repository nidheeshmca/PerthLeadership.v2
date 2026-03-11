using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Reporting;

namespace PerthLeadership.Infrastructure.Data.Configurations.Reporting;

public class FmInputScaleConfiguration : IEntityTypeConfiguration<FmInputScale>
{
    public void Configure(EntityTypeBuilder<FmInputScale> builder)
    {
        builder.ToTable("tblFmInputScale");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Mode).HasColumnName("mode").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Type).HasColumnName("type").HasColumnType("char(10)");
        builder.Property(e => e.Begin).HasColumnName("begin");
        builder.Property(e => e.End).HasColumnName("end");
        builder.Property(e => e.Super).HasColumnType("char(10)");
        builder.Property(e => e.Sub).HasColumnName("sub");
        builder.Property(e => e.Index).HasColumnName("index");
    }
}
