using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class ExoaTraitConfiguration : IEntityTypeConfiguration<ExoaTrait>
{
    public void Configure(EntityTypeBuilder<ExoaTrait> builder)
    {
        builder.ToTable("ExoaTraits");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Mode).HasMaxLength(50);
        builder.Property(e => e.Trait).HasMaxLength(50);
        builder.Property(e => e.Expl).HasColumnType("nvarchar(max)");
        builder.Property(e => e.NDExpl).HasColumnType("nvarchar(max)");
        builder.Property(e => e.ModelType).HasMaxLength(20).IsUnicode(false);
    }
}
