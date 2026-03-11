using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Client;

namespace PerthLeadership.Infrastructure.Data.Configurations.Client;

public class ClientContactConfiguration : IEntityTypeConfiguration<ClientContact>
{
    public void Configure(EntityTypeBuilder<ClientContact> builder)
    {
        builder.ToTable("tblClientContacts");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Salutation).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.FirstName).HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.LastName).HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.Address1).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.Address2).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.City).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Zip).HasMaxLength(10).IsUnicode(false);
        builder.Property(e => e.Country).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Phone1).HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.Phone2).HasMaxLength(20).IsUnicode(false);

        builder.HasOne(e => e.ClientOrganization)
            .WithMany(c => c.ClientContacts)
            .HasForeignKey(e => e.ClientId)
            .HasPrincipalKey(e => e.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
