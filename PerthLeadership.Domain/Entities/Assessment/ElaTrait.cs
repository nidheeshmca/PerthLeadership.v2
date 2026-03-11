using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Assessment;

public class ElaTrait : EntityBase
{
    public string? Mode { get; set; }
    public string? Trait { get; set; }
    public string? Expl { get; set; }
    public string? NDExpl { get; set; }
    public int? Version { get; set; }
}
