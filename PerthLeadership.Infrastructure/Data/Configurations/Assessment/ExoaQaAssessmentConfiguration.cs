using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class ExoaQaAssessmentConfiguration : IEntityTypeConfiguration<ExoaQaAssessment>
{
    public void Configure(EntityTypeBuilder<ExoaQaAssessment> builder)
    {
        builder.ToTable("EXOA_QAAssessments");
        builder.HasKey(e => e.Id);
    }
}
