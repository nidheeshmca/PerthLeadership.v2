using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Client;

public class CoachingSession : EntityBase
{
    public int? AssignProjectId { get; set; }
    public int? AssignSubjectId { get; set; }
    public string? PCC { get; set; }
    public int? Session { get; set; }
    public DateTime? SessionDate { get; set; }
    public string? SessionTime { get; set; }
    public string? SessionType { get; set; }
    public string? SessionStatus { get; set; }
    public string? POSTQAComplete { get; set; }
}
