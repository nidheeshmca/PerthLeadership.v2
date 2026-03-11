using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Reporting;

public class SubjectAssessmentReport : EntityBase
{
    public int? AssignSubjectId { get; set; }
    public string Status { get; set; } = null!;
    public DateTime? TakenOn { get; set; }
    public byte[]? Report { get; set; }
    public string? CouponNo { get; set; }
    public int? Version { get; set; }
}
