namespace PerthLeadership.Domain.Entities.Client;

public class Licensee
{
    public int LicenseeId { get; set; }
    public string? LicenseeName { get; set; }

    // Navigation properties
    public ICollection<Coupon> Coupons { get; set; } = [];
}
