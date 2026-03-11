using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Assessment;

public class AssessmentSignature : EntityBase
{
    public byte? VACategoryId { get; set; }
    public byte? RUCategoryId { get; set; }
    public int? SignatureId { get; set; }
    public string? Signature { get; set; }
    public string? ValuationOutcome { get; set; }
    public string? MissionImage { get; set; }
    public string? GraphImage { get; set; }
    public string? AssessmentType { get; set; }
}
