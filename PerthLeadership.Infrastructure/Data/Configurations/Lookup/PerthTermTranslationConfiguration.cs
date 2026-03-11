using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Lookup;

namespace PerthLeadership.Infrastructure.Data.Configurations.Lookup;

public class PerthTermTranslationConfiguration : IEntityTypeConfiguration<PerthTermTranslation>
{
    public void Configure(EntityTypeBuilder<PerthTermTranslation> builder)
    {
        builder.ToTable("PERTH_TERM_TRANSLATIONS");

        builder.HasKey(e => e.Id);

        builder.HasIndex(e => new { e.LanguageId, e.PerthTermId }).IsUnique().HasDatabaseName("IX_UNIQUE_PERTH_TERM_TRANSLATIONS");

        builder.Property(e => e.LanguageId).HasColumnName("LANGUAGE_ID");
        builder.Property(e => e.PerthTermId).HasColumnName("PERTH_TERM_ID");
        builder.Property(e => e.TranslatedTerm).HasColumnName("TRANSLATED_TERM").HasMaxLength(100);

        builder.HasOne(e => e.Language)
            .WithMany(l => l.Translations)
            .HasForeignKey(e => e.LanguageId)
            .HasPrincipalKey(e => e.LanguageId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.PerthTerm)
            .WithMany(t => t.Translations)
            .HasForeignKey(e => e.PerthTermId)
            .HasPrincipalKey(e => e.PerthTermId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
