using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Assessment;

public class ElaResult : EntityBase
{
    public long? PID { get; set; }
    public string? UserId { get; set; }
    public int? Question { get; set; }
    public string? Answer { get; set; }
    public int? Rating { get; set; }
    public DateTime? EnterDate { get; set; }
    public string? QuestionText { get; set; }
    public string? AnsTextLeft { get; set; }
    public string? AnsTextRight { get; set; }
}
