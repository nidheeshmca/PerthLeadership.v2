using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class AssessmentGroupConfiguration : IEntityTypeConfiguration<AssessmentGroup>
{
    public void Configure(EntityTypeBuilder<AssessmentGroup> builder)
    {
        builder.ToTable("AssessmentGroups");

        builder.HasKey(e => e.GroupId);

        builder.Property(e => e.GroupId)
            .HasColumnName("Groupid")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.GroupName).HasColumnName("groupname").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.AvgRU).HasColumnName("AVGRU");
        builder.Property(e => e.AvgVA).HasColumnName("AVGVA");
        builder.Property(e => e.AvgPast).HasColumnName("AVGPAST");
        builder.Property(e => e.AvgNow).HasColumnName("AVGNOW");
        builder.Property(e => e.AvgFuture).HasColumnName("AVGFUTURE");
        builder.Property(e => e.RefRU).HasColumnName("REFRU");
        builder.Property(e => e.RefVA).HasColumnName("REFVA");
        builder.Property(e => e.GroupStatus).HasColumnName("GroupStatus");
        builder.Property(e => e.AssessmentType).HasMaxLength(10).IsUnicode(false);
    }
}
