using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Assessment;

public class CfoaAssessment : EntityBase
{
    public long? PID { get; set; }
    public string? UserId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public DateTime? ResetDate { get; set; }
    public byte? TestStatus { get; set; }
    public int? SumVA { get; set; }
    public int? SumRU { get; set; }
    public decimal? Past { get; set; }
    public decimal? Now { get; set; }
    public decimal? Future { get; set; }
    public string? CompanyName { get; set; }
    public string? Signature { get; set; }
    public int? Cnt { get; set; }
}
