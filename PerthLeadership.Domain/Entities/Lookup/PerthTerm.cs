using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Lookup;

public class PerthTerm : EntityBase
{
    public int PerthTermId { get; set; }
    public string Term { get; set; } = null!;
    public string Token { get; set; } = null!;

    // Navigation properties
    public ICollection<PerthTermTranslation> Translations { get; set; } = [];
}
