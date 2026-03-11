using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Lookup;

public class PerthTermTranslation : EntityBase
{
    public int LanguageId { get; set; }
    public int PerthTermId { get; set; }
    public string? TranslatedTerm { get; set; }

    // Navigation properties
    public Language? Language { get; set; }
    public PerthTerm? PerthTerm { get; set; }
}
