using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class ElaTraitConfiguration : IEntityTypeConfiguration<ElaTrait>
{
    public void Configure(EntityTypeBuilder<ElaTrait> builder)
    {
        builder.ToTable("tblElaTriats");

        builder.HasKey(e => e.Id)
            .HasName("PK_tblElaTriats");

        builder.Property(e => e.Mode).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Trait).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Expl).HasColumnType("nvarchar(max)");
        builder.Property(e => e.NDExpl).HasColumnType("nvarchar(max)");
    }
}
