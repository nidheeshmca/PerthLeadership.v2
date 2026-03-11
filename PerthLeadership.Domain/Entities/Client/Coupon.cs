using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Client;

public class Coupon : EntityBase
{
    public int CouponId { get; set; }
    public string? CouponNo { get; set; }
    public string? CouponType { get; set; }
    public int? DaysToExpire { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? CreatedBy { get; set; }
    public int? ClientId { get; set; }
    public int? LicenseeId { get; set; }
    public string? SubjectReport { get; set; }
    public int? Version { get; set; }
    public int? CreatorId { get; set; }
    public string? Series { get; set; }
    public string? Comments { get; set; }
    public short? CouponLimit { get; set; }
    public int? ProjectId { get; set; }
    public string? AssessmentType { get; set; }
    public bool? UserReport { get; set; }
    public DateTime? DueDate { get; set; }

    // Navigation properties
    public ClientOrganization? ClientOrganization { get; set; }
    public Creator? Creator { get; set; }
    public Licensee? Licensee { get; set; }
    public ICollection<AssignCoupon> AssignCoupons { get; set; } = [];
}
