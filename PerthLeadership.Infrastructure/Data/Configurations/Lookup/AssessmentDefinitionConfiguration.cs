using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Lookup;

namespace PerthLeadership.Infrastructure.Data.Configurations.Lookup;

public class AssessmentDefinitionConfiguration : IEntityTypeConfiguration<AssessmentDefinition>
{
    public void Configure(EntityTypeBuilder<AssessmentDefinition> builder)
    {
        builder.ToTable("tblAssessmentDefinitions");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.AssessmentName).HasMaxLength(100).IsUnicode(false).IsRequired();
    }
}
