using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class AssessmentSignatureConfiguration : IEntityTypeConfiguration<AssessmentSignature>
{
    public void Configure(EntityTypeBuilder<AssessmentSignature> builder)
    {
        builder.ToTable("AssessmentSignatures");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.VACategoryId).HasColumnType("tinyint");
        builder.Property(e => e.RUCategoryId).HasColumnType("tinyint");
        builder.Property(e => e.Signature).HasMaxLength(100);
        builder.Property(e => e.ValuationOutcome).HasMaxLength(100);
        builder.Property(e => e.MissionImage).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.GraphImage).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.AssessmentType).HasMaxLength(10).IsUnicode(false);
    }
}
