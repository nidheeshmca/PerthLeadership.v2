namespace PerthLeadership.Domain.Entities.Assessment;

public class ExoaQaAssessment
{
    public int Id { get; set; }
    public string? CertifiedByAdminLogin { get; set; }
    public DateTime? WhenCertified { get; set; }
    public string? Status { get; set; }
    public string? Calibration { get; set; }
    public int? QType1Answer { get; set; }
    public int? QType2Answer { get; set; }
    public int? QType3Answer { get; set; }
    public int? QType4Answer { get; set; }
    public int? QType5Answer { get; set; }
    public int? QType6Answer { get; set; }
    public int? QType7Answer { get; set; }
    public int? QType8Answer { get; set; }
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
    public int? DominantMode2 { get; set; }
    public int? DominantType2 { get; set; }
    public int? NdType1 { get; set; }
    public int? NdType2 { get; set; }
    public int? NdType3 { get; set; }
    public int? NdType4 { get; set; }
    public string? FinMission { get; set; }
    public int? FMRU { get; set; }
    public int? FMVA { get; set; }
    public string? FMIntensityImage { get; set; }
    public int? FmIntensityVAMid { get; set; }
    public int? FmIntensityRUMid { get; set; }
}
