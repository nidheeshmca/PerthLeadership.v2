using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Assessment;

public class ExoaFinMission : EntityBase
{
    public string? Mode { get; set; }
    public int? Xcell { get; set; }
    public int? Ycell { get; set; }
    public string? FM { get; set; }
    public int? RUCategoryId { get; set; }
    public int? VACategoryId { get; set; }
}
