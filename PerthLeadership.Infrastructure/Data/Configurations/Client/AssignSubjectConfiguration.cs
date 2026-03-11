using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Client;

namespace PerthLeadership.Infrastructure.Data.Configurations.Client;

public class AssignSubjectConfiguration : IEntityTypeConfiguration<AssignSubject>
{
    public void Configure(EntityTypeBuilder<AssignSubject> builder)
    {
        builder.ToTable("tblAssignSubjects");

        builder.HasKey(e => e.Id);
        builder.HasAlternateKey(e => e.AssignSubjectId).HasName("AK_tblAssignSubjects_AssignSubjectId");

        builder.Property(e => e.AssignSubjectId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.HasOne(e => e.Subject)
            .WithMany(s => s.AssignSubjects)
            .HasForeignKey(e => e.SubjectId)
            .HasPrincipalKey(e => e.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.AssignProject)
            .WithMany(ap => ap.AssignSubjects)
            .HasForeignKey(e => e.AssignProjectId)
            .HasPrincipalKey(e => e.AssignProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
