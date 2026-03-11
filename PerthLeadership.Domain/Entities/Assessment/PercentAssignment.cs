using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Assessment;

public class PercentAssignment : EntityBase
{
    public int? CategoryId { get; set; }
    public int? LowerBound { get; set; }
    public int? UpperBound { get; set; }
    public string? AssessmentType { get; set; }
    public string? ScoreType { get; set; }
    public bool IsTemp { get; set; }
}
