namespace PerthLeadership.Domain.Entities.Admin;

public class MenuItem
{
    public int Mid { get; set; }
    public int? User { get; set; }
    public int? Parent { get; set; }
    public int? Sequence { get; set; }
    public string? Name { get; set; }
    public string? Link { get; set; }
    public bool? IsActive { get; set; }
}
