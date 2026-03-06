namespace PerthLeadership.Domain.Entities.Reporting;

public class SubjectAssessmentReport
{
    public int SubjectAssessmentReportId { get; set; }
    public int? AssignSubjectId { get; set; }
    public string Status { get; set; } = null!;
    public DateTime? TakenOn { get; set; }
    public byte[]? Report { get; set; }
    public string? CouponNo { get; set; }
    public int? Version { get; set; }
}
