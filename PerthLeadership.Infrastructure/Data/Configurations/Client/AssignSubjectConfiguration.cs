using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Client;

namespace PerthLeadership.Infrastructure.Data.Configurations.Client;

public class AssignSubjectConfiguration : IEntityTypeConfiguration<AssignSubject>
{
    public void Configure(EntityTypeBuilder<AssignSubject> builder)
    {
        builder.ToTable("tblAssignSubjects");

        builder.HasKey(e => e.AssignSubjectId);

        builder.Property(e => e.AssignSubjectId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.HasOne(e => e.Subject)
            .WithMany(s => s.AssignSubjects)
            .HasForeignKey(e => e.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.AssignProject)
            .WithMany(ap => ap.AssignSubjects)
            .HasForeignKey(e => e.AssignProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
