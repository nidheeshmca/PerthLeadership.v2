using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Lookup;

public class ExamTerm : EntityBase
{
    public string Exam { get; set; } = null!;
    public string Culture { get; set; } = null!;
    public string? Terms { get; set; }
}
