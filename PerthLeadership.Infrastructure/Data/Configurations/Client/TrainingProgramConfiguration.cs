using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Client;

namespace PerthLeadership.Infrastructure.Data.Configurations.Client;

public class TrainingProgramConfiguration : IEntityTypeConfiguration<TrainingProgram>
{
    public void Configure(EntityTypeBuilder<TrainingProgram> builder)
    {
        builder.ToTable("tblPrograms");

        builder.HasKey(e => e.Id);
        builder.HasAlternateKey(e => e.ProgramId).HasName("AK_tblPrograms_ProgramId");

        builder.Property(e => e.ProgramId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.ProgramName).HasMaxLength(50).IsUnicode(false).IsRequired();
        builder.Property(e => e.ProgramType).HasMaxLength(50).IsUnicode(false).IsRequired();
        builder.Property(e => e.ProgramCode).HasMaxLength(10).IsUnicode(false);
        builder.Property(e => e.ProgramCountry).HasMaxLength(50).IsUnicode(false);
    }
}
