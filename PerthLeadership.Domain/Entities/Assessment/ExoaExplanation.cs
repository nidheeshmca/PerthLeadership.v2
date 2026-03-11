using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Assessment;

public class ExoaExplanation : EntityBase
{
    public string? Name { get; set; }
    public string? Condition { get; set; }
    public string? Explanation1 { get; set; }
    public string? BottomLine { get; set; }
    public string? Prefrences { get; set; }
    public string? PrefExpl { get; set; }
    public string? LStyle { get; set; }
    public string? LStyleC { get; set; }
    public string? Explanation1C { get; set; }
    public string? ModelType { get; set; }
}
