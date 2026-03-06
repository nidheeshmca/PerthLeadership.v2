namespace PerthLeadership.Domain.Entities.Lookup;

public class PerthTerm
{
    public int Id { get; set; }
    public string Term { get; set; } = null!;
    public string Token { get; set; } = null!;

    // Navigation properties
    public ICollection<PerthTermTranslation> Translations { get; set; } = [];
}
