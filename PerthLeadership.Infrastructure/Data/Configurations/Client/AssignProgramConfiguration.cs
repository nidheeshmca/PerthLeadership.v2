using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Client;

namespace PerthLeadership.Infrastructure.Data.Configurations.Client;

public class AssignProgramConfiguration : IEntityTypeConfiguration<AssignProgram>
{
    public void Configure(EntityTypeBuilder<AssignProgram> builder)
    {
        builder.ToTable("tblAssignProgram");

        builder.HasKey(e => e.Id);
        builder.HasAlternateKey(e => e.AssignedProgramId).HasName("AK_tblAssignProgram_AssignedProgramId");

        builder.Property(e => e.AssignedProgramId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.Status).HasMaxLength(15).IsUnicode(false).IsRequired();
        builder.Property(e => e.Comments).HasMaxLength(2000).IsUnicode(false);

        builder.HasOne(e => e.TrainingProgram)
            .WithMany(p => p.AssignPrograms)
            .HasForeignKey(e => e.ProgramId)
            .HasPrincipalKey(e => e.ProgramId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ClientOrganization)
            .WithMany(c => c.AssignPrograms)
            .HasForeignKey(e => e.ClientId)
            .HasPrincipalKey(e => e.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
