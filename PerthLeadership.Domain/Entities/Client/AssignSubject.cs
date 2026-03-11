using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Client;

public class AssignSubject : EntityBase
{
    public int AssignSubjectId { get; set; }
    public int SubjectId { get; set; }
    public int AssignProjectId { get; set; }
    public int OverAllUserId { get; set; }
    public bool? ReportAccess { get; set; }

    // Navigation properties
    public Subject? Subject { get; set; }
    public AssignProject? AssignProject { get; set; }
}
