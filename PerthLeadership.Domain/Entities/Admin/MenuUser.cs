using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Admin;

public class MenuUser : EntityBase
{
    public string? User { get; set; }
    public string? Pass { get; set; }
    public string? Group { get; set; }
    public bool? Activation { get; set; }
    public int? Sequence { get; set; }
    public string? Privilege { get; set; }
    public int? OverAllUserId { get; set; }
    public string? Firstname { get; set; }
    public string? LastName { get; set; }
    public string? Title { get; set; }
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public int? State { get; set; }
    public string? Zip { get; set; }
    public string? Country { get; set; }
    public string? Phone1 { get; set; }
    public string? Phone2 { get; set; }
    public string? EmailId { get; set; }
}
