using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Client;

public class OverAllUser : EntityBase
{
    public int OverallUserId { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string UserType { get; set; } = null!;
    public string? UserName { get; set; }
    public string? Role { get; set; }
    public DateTime? CreatedOn { get; set; }
    public bool? IsActive { get; set; }

    // Navigation properties
    public ICollection<Subject> Subjects { get; set; } = [];
    public ICollection<ClientOrganization> ClientOrganizations { get; set; } = [];
}
