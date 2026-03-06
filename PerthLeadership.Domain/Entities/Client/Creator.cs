namespace PerthLeadership.Domain.Entities.Client;

public class Creator
{
    public int CreatorId { get; set; }
    public string? CreatorName { get; set; }

    // Navigation properties
    public ICollection<Coupon> Coupons { get; set; } = [];
}
