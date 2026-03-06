using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class CfoaAssessmentConfiguration : IEntityTypeConfiguration<CfoaAssessment>
{
    public void Configure(EntityTypeBuilder<CfoaAssessment> builder)
    {
        builder.ToTable("CFOA_Assessment");

        builder.HasKey(e => e.Id)
            .HasName("PK_CFOA_Assessment");

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.UserId).HasMaxLength(50);
        builder.Property(e => e.TestStatus).HasColumnType("tinyint");
        builder.Property(e => e.Past).HasColumnType("decimal(18, 0)");
        builder.Property(e => e.Now).HasColumnType("decimal(18, 0)");
        builder.Property(e => e.Future).HasColumnType("decimal(18, 0)");
        builder.Property(e => e.CompanyName).HasColumnName("Companyname").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Signature).HasMaxLength(100);
        builder.Property(e => e.Cnt).HasColumnName("cnt");
    }
}
