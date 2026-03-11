using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Assessment;

public class ImageSetting : EntityBase
{
    public int? RUCategoryId { get; set; }
    public int? VACategoryId { get; set; }
    public int? ImageTop { get; set; }
    public int? ImageLeft { get; set; }
    public string? AssessmentType { get; set; }
}
