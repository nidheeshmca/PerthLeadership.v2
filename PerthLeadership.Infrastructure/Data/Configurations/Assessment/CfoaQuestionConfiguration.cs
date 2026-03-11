using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class CfoaQuestionConfiguration : IEntityTypeConfiguration<CfoaQuestion>
{
    public void Configure(EntityTypeBuilder<CfoaQuestion> builder)
    {
        builder.ToTable("cFOA_Questions");

        builder.HasKey(e => e.Id)
            .HasName("PK_CFOA_Questions");

        builder.Property(e => e.Question).HasColumnType("nvarchar(max)");
        builder.Property(e => e.QA).HasMaxLength(255);
        builder.Property(e => e.QB).HasMaxLength(100);
        builder.Property(e => e.QC).HasMaxLength(100);
        builder.Property(e => e.QD).HasMaxLength(100);
        builder.Property(e => e.QE).HasMaxLength(100);
        builder.Property(e => e.QF).HasMaxLength(255);
        builder.Property(e => e.Type).HasColumnType("char(1)");
        builder.Property(e => e.Category).HasMaxLength(50);
    }
}
