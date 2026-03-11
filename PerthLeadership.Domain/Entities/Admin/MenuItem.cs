using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Admin;

public class MenuItem : EntityBase
{
    public int? User { get; set; }
    public int? Parent { get; set; }
    public int? Sequence { get; set; }
    public string? Name { get; set; }
    public string? Link { get; set; }
    public bool? IsActive { get; set; }
}
