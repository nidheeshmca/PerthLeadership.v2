using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Assessment;

public class AssessmentUserGroup : EntityBase
{
    public int UserId { get; set; }
    public int GroupId { get; set; }

    // Navigation properties
    public AssessmentGroup? Group { get; set; }
}
