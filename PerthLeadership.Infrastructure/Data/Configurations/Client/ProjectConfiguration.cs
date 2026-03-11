using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Client;

namespace PerthLeadership.Infrastructure.Data.Configurations.Client;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("tblProjects");

        builder.HasKey(e => e.Id);
        builder.HasAlternateKey(e => e.ProjectId).HasName("AK_tblProjects_ProjectId");

        builder.Property(e => e.ProjectId)
            .HasColumnName("Projectid")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.ProjectName).HasMaxLength(50).IsUnicode(false).IsRequired();
        builder.Property(e => e.ProjectManager).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.ProjectCode).HasMaxLength(10).IsUnicode(false);
        builder.Property(e => e.PMName).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.ProjectCountry).HasMaxLength(50).IsUnicode(false);

        builder.HasOne(e => e.TrainingProgram)
            .WithMany(p => p.Projects)
            .HasForeignKey(e => e.ProgramId)
            .HasPrincipalKey(e => e.ProgramId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
