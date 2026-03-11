using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Client;

namespace PerthLeadership.Infrastructure.Data.Configurations.Client;

public class ClientOrganizationConfiguration : IEntityTypeConfiguration<ClientOrganization>
{
    public void Configure(EntityTypeBuilder<ClientOrganization> builder)
    {
        builder.ToTable("tblClients");

        builder.HasKey(e => e.Id);
        builder.HasAlternateKey(e => e.ClientId).HasName("AK_tblClients_ClientId");

        builder.Property(e => e.ClientId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn(1000, 1);

        builder.Property(e => e.ClientCode).HasMaxLength(10).IsUnicode(false);
        builder.Property(e => e.CompanyName).HasMaxLength(150).IsUnicode(false).IsRequired();
        builder.Property(e => e.Address1).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.Address2).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.City).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Zip).HasMaxLength(10).IsUnicode(false);
        builder.Property(e => e.Country).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Website).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.PhoneNo1).HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.PhoneNo2).HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.Status).HasMaxLength(20).IsUnicode(false).IsRequired();
        builder.Property(e => e.Comments).HasMaxLength(2000).IsUnicode(false);
        builder.Property(e => e.BillingAddress1).HasMaxLength(100).IsUnicode(false).IsRequired();
        builder.Property(e => e.BillingAddress2).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.BillingCity).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.BillingState).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.BillingZip).HasMaxLength(10).IsUnicode(false);
        builder.Property(e => e.BillingCountry).HasMaxLength(50).IsUnicode(false).IsRequired();
        builder.Property(e => e.BillingPhoneNo1).HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.BillingPhoneNo2).HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.ShippingAddress1).HasMaxLength(100).IsUnicode(false).IsRequired();
        builder.Property(e => e.ShippingAddress2).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.ShippingCity).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.ShippingState).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.ShippingZip).HasMaxLength(10).IsUnicode(false);
        builder.Property(e => e.ShippingCountry).HasMaxLength(50).IsUnicode(false).IsRequired();
        builder.Property(e => e.ShippingPhone1).HasMaxLength(20).IsUnicode(false);
        builder.Property(e => e.ShippingPhone2).HasMaxLength(20).IsUnicode(false);

        builder.HasOne(e => e.OverAllUser)
            .WithMany(u => u.ClientOrganizations)
            .HasForeignKey(e => e.OverAllUserId)
            .HasPrincipalKey(e => e.OverallUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
