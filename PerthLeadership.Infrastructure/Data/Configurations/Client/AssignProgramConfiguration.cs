using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Client;

namespace PerthLeadership.Infrastructure.Data.Configurations.Client;

public class AssignProgramConfiguration : IEntityTypeConfiguration<AssignProgram>
{
    public void Configure(EntityTypeBuilder<AssignProgram> builder)
    {
        builder.ToTable("tblAssignProgram");

        builder.HasKey(e => e.AssignedProgramId)
            .HasName("PK_tblAssignProgram");

        builder.Property(e => e.AssignedProgramId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.Status).HasMaxLength(15).IsUnicode(false).IsRequired();
        builder.Property(e => e.Comments).HasMaxLength(2000).IsUnicode(false);

        builder.HasOne(e => e.TrainingProgram)
            .WithMany(p => p.AssignPrograms)
            .HasForeignKey(e => e.ProgramId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ClientOrganization)
            .WithMany(c => c.AssignPrograms)
            .HasForeignKey(e => e.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
