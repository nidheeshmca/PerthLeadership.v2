using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Admin;

public class PerthAdminPermission : EntityBase
{
    public int? UserId { get; set; }
    public int? MenuId { get; set; }
}
