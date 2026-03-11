using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Assessment;

namespace PerthLeadership.Infrastructure.Data.Configurations.Assessment;

public class ElaModeConfiguration : IEntityTypeConfiguration<ElaMode>
{
    public void Configure(EntityTypeBuilder<ElaMode> builder)
    {
        builder.ToTable("tblElaMode");

        builder.HasKey(e => e.Id)
            .HasName("PK_tblElaMode");

        builder.Property(e => e.Mode).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Expl).HasColumnType("nvarchar(max)");
        builder.Property(e => e.NDExpl).HasColumnName("NDEXpl").HasColumnType("nvarchar(max)");
    }
}
