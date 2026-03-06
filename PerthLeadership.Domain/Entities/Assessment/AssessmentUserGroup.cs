namespace PerthLeadership.Domain.Entities.Assessment;

public class AssessmentUserGroup
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int GroupId { get; set; }

    // Navigation properties
    public AssessmentGroup? Group { get; set; }
}
