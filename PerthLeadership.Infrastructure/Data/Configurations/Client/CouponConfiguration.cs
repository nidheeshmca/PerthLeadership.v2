using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Client;

namespace PerthLeadership.Infrastructure.Data.Configurations.Client;

public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.ToTable("tblCoupons");

        builder.HasKey(e => e.Id);
        builder.HasAlternateKey(e => e.CouponId).HasName("AK_tblCoupons_CouponId");

        builder.Property(e => e.CouponId)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(e => e.CouponNo).HasMaxLength(25).IsUnicode(false);
        builder.Property(e => e.CouponType).HasMaxLength(25).IsUnicode(false);
        builder.Property(e => e.SubjectReport).HasMaxLength(100).IsUnicode(false);
        builder.Property(e => e.Series).HasMaxLength(10).IsUnicode(false);
        builder.Property(e => e.Comments).HasColumnType("nvarchar(max)");
        builder.Property(e => e.AssessmentType).HasMaxLength(50).IsUnicode(false);

        builder.HasOne(e => e.ClientOrganization)
            .WithMany(c => c.Coupons)
            .HasForeignKey(e => e.ClientId)
            .HasPrincipalKey(e => e.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Creator)
            .WithMany(c => c.Coupons)
            .HasForeignKey(e => e.CreatorId)
            .HasPrincipalKey(e => e.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Licensee)
            .WithMany(l => l.Coupons)
            .HasForeignKey(e => e.LicenseeId)
            .HasPrincipalKey(e => e.LicenseeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
