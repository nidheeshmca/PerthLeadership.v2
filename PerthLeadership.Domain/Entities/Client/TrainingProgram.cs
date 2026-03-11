using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Client;

public class TrainingProgram : EntityBase
{
    public int ProgramId { get; set; }
    public string ProgramName { get; set; } = null!;
    public string ProgramType { get; set; } = null!;
    public int OverAllUserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? ProgramCode { get; set; }
    public string? ProgramCountry { get; set; }
    public string? Status { get; set; }
    public string? Description { get; set; }

    // Navigation properties
    public ICollection<Project> Projects { get; set; } = [];
    public ICollection<AssignProgram> AssignPrograms { get; set; } = [];
}
