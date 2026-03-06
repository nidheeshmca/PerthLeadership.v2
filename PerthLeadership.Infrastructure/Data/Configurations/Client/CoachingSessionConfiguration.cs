using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Client;

namespace PerthLeadership.Infrastructure.Data.Configurations.Client;

public class CoachingSessionConfiguration : IEntityTypeConfiguration<CoachingSession>
{
    public void Configure(EntityTypeBuilder<CoachingSession> builder)
    {
        builder.ToTable("tblCoachingSession");

        builder.HasKey(e => e.CoachId);

        builder.Property(e => e.CoachId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.PCC).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.SessionTime).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.SessionType).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.SessionStatus).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.POSTQAComplete).HasMaxLength(50).IsUnicode(false);
    }
}
