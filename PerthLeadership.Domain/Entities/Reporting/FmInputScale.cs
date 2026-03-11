using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Reporting;

public class FmInputScale : EntityBase
{
    public string? Mode { get; set; }
    public string? Type { get; set; }
    public double? Begin { get; set; }
    public double? End { get; set; }
    public string? Super { get; set; }
    public int? Sub { get; set; }
    public int? Index { get; set; }
}
