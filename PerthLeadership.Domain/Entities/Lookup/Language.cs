namespace PerthLeadership.Domain.Entities.Lookup;

public class Language
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? TranslatedName { get; set; }

    // Navigation properties
    public ICollection<PerthTermTranslation> Translations { get; set; } = [];
}
