namespace PerthLeadership.Domain.Entities.Reporting;

public class FmIntensity
{
    public long Id { get; set; }
    public long? VaId { get; set; }
    public long? RuId { get; set; }
    public string? Mode { get; set; }
    public int? IndexRU { get; set; }
    public int? IndexVA { get; set; }
    public string? FMIntensityValue { get; set; }
}
