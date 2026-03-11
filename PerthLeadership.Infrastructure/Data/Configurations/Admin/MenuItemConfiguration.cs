using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Admin;

namespace PerthLeadership.Infrastructure.Data.Configurations.Admin;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.ToTable("tblMenuItem");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.User).HasColumnName("User");
        builder.Property(e => e.Parent).HasColumnName("Parent");
        builder.Property(e => e.Sequence).HasColumnName("Sequence");
        builder.Property(e => e.Name).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Link).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.IsActive).HasColumnName("IsActive");
    }
}
