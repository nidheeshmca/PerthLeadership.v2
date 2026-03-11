using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Document;

namespace PerthLeadership.Infrastructure.Data.Configurations.Document;

public class AttachedDocumentConfiguration : IEntityTypeConfiguration<AttachedDocument>
{
    public void Configure(EntityTypeBuilder<AttachedDocument> builder)
    {
        builder.ToTable("tblAttachedDocuments");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.ReferenceId).HasColumnName("ReferenceID").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.ReferenceType).HasColumnName("RefrenceType").HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Title).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.DocumentName).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.Content).HasColumnName("content").HasColumnType("varbinary(max)");
        builder.Property(e => e.ContentType).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Description).HasMaxLength(500).IsUnicode(false);
    }
}
