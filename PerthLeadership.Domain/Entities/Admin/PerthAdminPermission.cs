namespace PerthLeadership.Domain.Entities.Admin;

public class PerthAdminPermission
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public int? MenuId { get; set; }
}
