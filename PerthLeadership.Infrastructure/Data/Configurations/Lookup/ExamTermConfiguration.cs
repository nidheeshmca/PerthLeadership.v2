using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Lookup;

namespace PerthLeadership.Infrastructure.Data.Configurations.Lookup;

public class ExamTermConfiguration : IEntityTypeConfiguration<ExamTerm>
{
    public void Configure(EntityTypeBuilder<ExamTerm> builder)
    {
        builder.ToTable("Exam_Terms");

        builder.HasKey(e => e.Id);

        builder.HasIndex(e => new { e.Exam, e.Culture }).IsUnique().HasDatabaseName("IX_UNIQUE_Exam_Terms");

        builder.Property(e => e.Exam).HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.Culture).HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.Terms).HasColumnType("nvarchar(max)");
    }
}
