using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Client;

public class Licensee : EntityBase
{
    public int LicenseeId { get; set; }
    public string? LicenseeName { get; set; }

    // Navigation properties
    public ICollection<Coupon> Coupons { get; set; } = [];
}
