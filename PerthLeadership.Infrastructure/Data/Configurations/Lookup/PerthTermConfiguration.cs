using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Lookup;

namespace PerthLeadership.Infrastructure.Data.Configurations.Lookup;

public class PerthTermConfiguration : IEntityTypeConfiguration<PerthTerm>
{
    public void Configure(EntityTypeBuilder<PerthTerm> builder)
    {
        builder.ToTable("PERTH_TERMS");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("RowId");

        builder.HasAlternateKey(e => e.PerthTermId).HasName("AK_PERTH_TERMS_PerthTermId");

        builder.Property(e => e.PerthTermId)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.Term)
            .HasColumnName("TERM")
            .HasMaxLength(100)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(e => e.Token)
            .HasColumnName("TOKEN")
            .HasMaxLength(100)
            .IsUnicode(false)
            .IsRequired();

        builder.HasIndex(e => e.Term)
            .IsUnique()
            .HasDatabaseName("IX_UNIQUE_PERTH_TERM");
    }
}
