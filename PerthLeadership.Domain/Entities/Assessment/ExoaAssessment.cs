using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Assessment;

public class ExoaAssessment : EntityBase
{
    public long? PID { get; set; }
    public string? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public DateTime? ResetDate { get; set; }
    public string? TestStatus { get; set; }
    public int? Cnt { get; set; }
    public int? OriginalScore1 { get; set; }
    public int? OriginalScore2 { get; set; }
    public int? OriginalScore3 { get; set; }
    public int? OriginalScore4 { get; set; }
    public int? OriginalScore5 { get; set; }
    public int? OriginalScore6 { get; set; }
    public int? OriginalScore7 { get; set; }
    public int? OriginalScore8 { get; set; }
    public int? OriginalModeScore1 { get; set; }
    public int? OriginalModeScore2 { get; set; }
    public int? OriginalModeScore3 { get; set; }
    public int? OriginalModeScore4 { get; set; }
    public string? Calibration { get; set; }
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
    public int? DominantMode2 { get; set; }
    public int? DominantType2 { get; set; }
    public string? CompanyName { get; set; }
    public string? FinMission { get; set; }
    public int? FMRU { get; set; }
    public int? FMVA { get; set; }
    public DateTime? FMDate { get; set; }
    public string? FMIntensityImage { get; set; }
    public int? FmIntensityVAMid { get; set; }
    public int? FmIntensityRUMid { get; set; }
}
