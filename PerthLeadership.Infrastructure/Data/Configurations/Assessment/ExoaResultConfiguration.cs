using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class ExoaResultConfiguration : IEntityTypeConfiguration<ExoaResult>
{
    public void Configure(EntityTypeBuilder<ExoaResult> builder)
    {
        builder.ToTable("Exoa_Results");

        builder.HasKey(e => e.Id)
            .HasName("PK_Exoa_Results");

        builder.Property(e => e.UserId).HasColumnName("UserID").HasMaxLength(255);
        builder.Property(e => e.Answer).HasMaxLength(50);
        builder.Property(e => e.EnterDate).HasColumnType("smalldatetime");
        builder.Property(e => e.QuestionText).HasColumnType("nvarchar(max)");
        builder.Property(e => e.AnsTextLeft).HasColumnType("nvarchar(max)");
        builder.Property(e => e.AnsTextRight).HasColumnType("nvarchar(max)");
    }
}
