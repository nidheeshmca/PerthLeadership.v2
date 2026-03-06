using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Reporting;

namespace PerthLeadership.Infrastructure.Data.Configurations.Reporting;

public class SubjectAssessmentReportConfiguration : IEntityTypeConfiguration<SubjectAssessmentReport>
{
    public void Configure(EntityTypeBuilder<SubjectAssessmentReport> builder)
    {
        builder.ToTable("tblSubjectAssessmentReports");

        builder.HasKey(e => e.SubjectAssessmentReportId)
            .HasName("PK_tblSubjectAssessmentReports");

        builder.Property(e => e.SubjectAssessmentReportId)
            .HasColumnName("SubjectAssessmentReportID")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.Status).HasMaxLength(20).IsUnicode(false).IsRequired();
        builder.Property(e => e.Report).HasColumnType("binary(50)");
        builder.Property(e => e.CouponNo).HasMaxLength(25).IsUnicode(false);
    }
}
