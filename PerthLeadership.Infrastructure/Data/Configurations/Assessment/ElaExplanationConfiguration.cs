using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class ElaExplanationConfiguration : IEntityTypeConfiguration<ElaExplanation>
{
    public void Configure(EntityTypeBuilder<ElaExplanation> builder)
    {
        builder.ToTable("tblElaExplanation");

        builder.HasKey(e => e.Id)
            .HasName("PK_tblElaExplanation");

        builder.Property(e => e.Name).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Condition).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Explanation).HasColumnType("nvarchar(max)");
        builder.Property(e => e.BottomLine).HasColumnType("nvarchar(max)");
    }
}
