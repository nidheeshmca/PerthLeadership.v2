using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerthLeadership.Domain.Entities.Client;

namespace PerthLeadership.Infrastructure.Data.Configurations.Client;

public class AssignCouponConfiguration : IEntityTypeConfiguration<AssignCoupon>
{
    public void Configure(EntityTypeBuilder<AssignCoupon> builder)
    {
        builder.ToTable("tblAssignCoupons");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Msg).HasColumnType("nvarchar(max)");
        builder.Property(e => e.AssessmentType).HasMaxLength(50).IsUnicode(false);
        builder.Property(e => e.Status).HasMaxLength(20).IsUnicode(false);

        builder.HasOne(e => e.Coupon)
            .WithMany(c => c.AssignCoupons)
            .HasForeignKey(e => e.CouponId)
            .HasPrincipalKey(e => e.CouponId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Subject)
            .WithMany(s => s.AssignCoupons)
            .HasForeignKey(e => e.SubjectId)
            .HasPrincipalKey(e => e.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.AssignSubject)
            .WithMany()
            .HasForeignKey(e => e.AssignSubjectId)
            .HasPrincipalKey(e => e.AssignSubjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
