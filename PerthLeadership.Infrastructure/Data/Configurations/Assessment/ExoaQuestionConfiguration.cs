using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class ExoaQuestionConfiguration : IEntityTypeConfiguration<ExoaQuestion>
{
    public void Configure(EntityTypeBuilder<ExoaQuestion> builder)
    {
        builder.ToTable("EXOAQuestions");

        builder.HasKey(e => e.Id)
            .HasName("PK_EXOAQuestions");

        builder.Property(e => e.Id)
            .HasColumnName("ID")
            .ValueGeneratedNever();

        builder.Property(e => e.Question).HasColumnType("nvarchar(max)");
        builder.Property(e => e.AnsLeft).HasMaxLength(255);
        builder.Property(e => e.AnsRight).HasMaxLength(255);
        builder.Property(e => e.LastModify).HasColumnType("smalldatetime");
    }
}
