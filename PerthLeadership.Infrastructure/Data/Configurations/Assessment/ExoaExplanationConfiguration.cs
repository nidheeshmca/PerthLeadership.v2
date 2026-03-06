using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class ExoaExplanationConfiguration : IEntityTypeConfiguration<ExoaExplanation>
{
    public void Configure(EntityTypeBuilder<ExoaExplanation> builder)
    {
        builder.ToTable("ExoaExplanations");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("ID")
            .ValueGeneratedNever();

        builder.Property(e => e.Name).HasMaxLength(100);
        builder.Property(e => e.Condition).HasColumnName("condition").HasMaxLength(255);
        builder.Property(e => e.Explanation1).HasColumnType("nvarchar(max)");
        builder.Property(e => e.BottomLine).HasColumnType("nvarchar(max)");
        builder.Property(e => e.Prefrences).HasMaxLength(200);
        builder.Property(e => e.PrefExpl).HasColumnName("prefexpl").HasColumnType("nvarchar(max)");
        builder.Property(e => e.LStyle).HasColumnName("lstyle").HasColumnType("nvarchar(max)");
        builder.Property(e => e.LStyleC).HasColumnName("lstylec").HasColumnType("nvarchar(max)");
        builder.Property(e => e.Explanation1C).HasColumnName("Explanation1c").HasColumnType("nvarchar(max)");
        builder.Property(e => e.ModelType).HasMaxLength(20).IsUnicode(false);
    }
}
