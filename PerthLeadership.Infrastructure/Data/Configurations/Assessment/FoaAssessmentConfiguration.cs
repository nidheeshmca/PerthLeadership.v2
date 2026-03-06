using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class FoaAssessmentConfiguration : IEntityTypeConfiguration<FoaAssessment>
{
    public void Configure(EntityTypeBuilder<FoaAssessment> builder)
    {
        builder.ToTable("FOA_Assessment");

        builder.HasKey(e => e.Id)
            .HasName("PK_FOA_Assessment");

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.UserId).HasMaxLength(50);
        builder.Property(e => e.TestStatus).HasColumnType("tinyint");
        builder.Property(e => e.Past).HasColumnType("decimal(18, 0)");
        builder.Property(e => e.Now).HasColumnType("decimal(18, 0)");
        builder.Property(e => e.Future).HasColumnType("decimal(18, 0)");
        builder.Property(e => e.CompanyName).HasMaxLength(50);
        builder.Property(e => e.Signature).HasMaxLength(50);
    }
}
