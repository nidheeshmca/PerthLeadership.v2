using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Lookup;

public class Country : EntityBase
{
    public string? CountryName { get; set; }
    public string? CountryCode { get; set; }
    public int? RegionId { get; set; }
}
