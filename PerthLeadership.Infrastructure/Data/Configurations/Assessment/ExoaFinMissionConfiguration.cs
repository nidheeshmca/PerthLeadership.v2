using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class ExoaFinMissionConfiguration : IEntityTypeConfiguration<ExoaFinMission>
{
    public void Configure(EntityTypeBuilder<ExoaFinMission> builder)
    {
        builder.ToTable("EXOA_FinMission");

        builder.HasKey(e => e.FinMissId);

        builder.Property(e => e.FinMissId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.Mode).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.FM).HasMaxLength(20).IsUnicode(false);
    }
}
