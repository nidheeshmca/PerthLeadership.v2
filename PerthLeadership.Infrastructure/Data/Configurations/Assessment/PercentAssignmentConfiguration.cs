using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class PercentAssignmentConfiguration : IEntityTypeConfiguration<PercentAssignment>
{
    public void Configure(EntityTypeBuilder<PercentAssignment> builder)
    {
        builder.ToTable("PercentAssignments");
        builder.HasKey(e => e.Id);
    }
}
