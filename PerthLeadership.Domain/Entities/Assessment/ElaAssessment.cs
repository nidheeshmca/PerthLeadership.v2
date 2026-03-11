using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Assessment;

public class ElaAssessment : EntityBase
{
    public long? PID { get; set; }
    public string? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public DateTime? ResetDate { get; set; }
    public string? TestStatus { get; set; }
    public int? Cnt { get; set; }
    public int? Score1 { get; set; }
    public int? Score2 { get; set; }
    public int? Score3 { get; set; }
    public int? Score4 { get; set; }
    public int? Score5 { get; set; }
    public int? Score6 { get; set; }
    public int? Score7 { get; set; }
    public int? Score8 { get; set; }
    public int? ModeScore1 { get; set; }
    public int? ModeScore2 { get; set; }
    public int? ModeScore3 { get; set; }
    public int? ModeScore4 { get; set; }
    public int? DominantMode { get; set; }
    public int? DominantType { get; set; }
    public int? NdType1 { get; set; }
    public int? NdType2 { get; set; }
    public int? NdType3 { get; set; }
    public int? NdType4 { get; set; }
}
