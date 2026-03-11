using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Admin;

public class AdminLog : EntityBase
{
    public DateTime? LogDate { get; set; }
    public string? AdminName { get; set; }
}
