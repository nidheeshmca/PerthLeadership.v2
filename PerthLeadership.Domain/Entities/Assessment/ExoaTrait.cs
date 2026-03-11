using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Assessment;

public class ExoaTrait : EntityBase
{
    public string? Mode { get; set; }
    public string? Trait { get; set; }
    public string? Expl { get; set; }
    public string? NDExpl { get; set; }
    public string? ModelType { get; set; }
}
