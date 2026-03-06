using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Client;

namespace PerthLeadership.Infrastructure.Data.Configurations.Client;

public class AssignProjectConfiguration : IEntityTypeConfiguration<AssignProject>
{
    public void Configure(EntityTypeBuilder<AssignProject> builder)
    {
        builder.ToTable("tblAssignProjects");

        builder.HasKey(e => e.AssignProjectId);

        builder.Property(e => e.AssignProjectId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.Status).HasMaxLength(15).IsUnicode(false);
        builder.Property(e => e.Comments).HasColumnType("nvarchar(max)");
        builder.Property(e => e.ReportLocation).HasMaxLength(50).IsUnicode(false);

        builder.HasOne(e => e.Project)
            .WithMany(p => p.AssignProjects)
            .HasForeignKey(e => e.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.AssignProgram)
            .WithMany(ap => ap.AssignProjects)
            .HasForeignKey(e => e.AssignProgramId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
