namespace PerthLeadership.Domain.Entities.Lookup;

public class Country
{
    public int CountryId { get; set; }
    public string? CountryName { get; set; }
    public string? CountryCode { get; set; }
    public int? RegionId { get; set; }
}
