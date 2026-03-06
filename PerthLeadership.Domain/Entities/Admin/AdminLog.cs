namespace PerthLeadership.Domain.Entities.Admin;

public class AdminLog
{
    public int Id { get; set; }
    public DateTime? LogDate { get; set; }
    public string? AdminName { get; set; }
}
