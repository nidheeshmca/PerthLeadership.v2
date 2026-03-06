namespace PerthLeadership.Domain.Entities.Assessment;

public class ExoaQuestion
{
    public int Id { get; set; }
    public string? Question { get; set; }
    public string? AnsLeft { get; set; }
    public string? AnsRight { get; set; }
    public int? Type { get; set; }
    public bool TieBreaking { get; set; }
    public int? A { get; set; }
    public int? B { get; set; }
    public int? C { get; set; }
    public int? D { get; set; }
    public int? E { get; set; }
    public int? F { get; set; }
    public DateTime? LastModify { get; set; }
}
