using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Client;

namespace PerthLeadership.Infrastructure.Data.Configurations.Client;

public class CreatorConfiguration : IEntityTypeConfiguration<Creator>
{
    public void Configure(EntityTypeBuilder<Creator> builder)
    {
        builder.ToTable("tblCreator");

        builder.HasKey(e => e.Id);
        builder.HasAlternateKey(e => e.CreatorId).HasName("AK_tblCreator_CreatorId");

        builder.Property(e => e.CreatorId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.CreatorName).HasMaxLength(50).IsUnicode(false);
    }
}
