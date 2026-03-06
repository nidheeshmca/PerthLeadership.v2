namespace PerthLeadership.Domain.Entities.Assessment;

public class AssessmentGroup
{
    public int GroupId { get; set; }
    public string? GroupName { get; set; }
    public int? AvgRU { get; set; }
    public int? AvgVA { get; set; }
    public int? AvgPast { get; set; }
    public int? AvgNow { get; set; }
    public int? AvgFuture { get; set; }
    public int? RefRU { get; set; }
    public int? RefVA { get; set; }
    public bool? GroupStatus { get; set; }
    public string? AssessmentType { get; set; }

    // Navigation properties
    public ICollection<AssessmentUserGroup> UserGroups { get; set; } = [];
}
