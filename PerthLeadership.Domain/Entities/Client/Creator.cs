using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Client;

public class Creator : EntityBase
{
    public int CreatorId { get; set; }
    public string? CreatorName { get; set; }

    // Navigation properties
    public ICollection<Coupon> Coupons { get; set; } = [];
}
