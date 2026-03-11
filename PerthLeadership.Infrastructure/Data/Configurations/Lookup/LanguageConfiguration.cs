using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Lookup;

namespace PerthLeadership.Infrastructure.Data.Configurations.Lookup;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable("LANGUAGES");

        builder.HasKey(e => e.Id);

        builder.HasAlternateKey(e => e.LanguageId).HasName("AK_LANGUAGES_LanguageId");

        builder.Property(e => e.LanguageId)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.Name)
            .HasColumnName("NAME")
            .HasMaxLength(50)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(e => e.TranslatedName)
            .HasColumnName("TRANSLATED_NAME")
            .HasMaxLength(50);

        builder.HasIndex(e => e.Name)
            .IsUnique()
            .HasDatabaseName("IX_UNIQUE_LANGUAGE_NAME");
    }
}
