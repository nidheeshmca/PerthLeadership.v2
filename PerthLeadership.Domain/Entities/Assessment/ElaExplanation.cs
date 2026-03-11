using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Assessment;

public class ElaExplanation : EntityBase
{
    public string? Name { get; set; }
    public string? Condition { get; set; }
    public string? Explanation { get; set; }
    public string? BottomLine { get; set; }
    public int? Version { get; set; }
}
