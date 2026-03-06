using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class ExoaModeConfiguration : IEntityTypeConfiguration<ExoaMode>
{
    public void Configure(EntityTypeBuilder<ExoaMode> builder)
    {
        builder.ToTable("ExoaModes");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("ID")
            .ValueGeneratedNever();

        builder.Property(e => e.Mode).HasMaxLength(100);
        builder.Property(e => e.Expl).HasColumnType("nvarchar(max)");
        builder.Property(e => e.NDExpl).HasColumnType("nvarchar(max)");
        builder.Property(e => e.ModelType).HasMaxLength(20).IsUnicode(false);
    }
}
