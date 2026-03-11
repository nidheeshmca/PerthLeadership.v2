using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class AssessmentUserGroupConfiguration : IEntityTypeConfiguration<AssessmentUserGroup>
{
    public void Configure(EntityTypeBuilder<AssessmentUserGroup> builder)
    {
        builder.ToTable("AssessmentUserGroups");
        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Group)
            .WithMany(g => g.UserGroups)
            .HasForeignKey(e => e.GroupId)
            .HasPrincipalKey(e => e.GroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
