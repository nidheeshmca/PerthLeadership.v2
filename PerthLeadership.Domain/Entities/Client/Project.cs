using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Client;

public class Project : EntityBase
{
    public int ProjectId { get; set; }
    public int ProgramId { get; set; }
    public string ProjectName { get; set; } = null!;
    public int OverAllUserId { get; set; }
    public DateTime CreatedOn { get; set; }
    public string? ProjectManager { get; set; }
    public string? ProjectCode { get; set; }
    public string? PMName { get; set; }
    public string? ProjectCountry { get; set; }
    public string? Status { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Comments { get; set; }

    // Navigation properties
    public TrainingProgram? TrainingProgram { get; set; }
    public ICollection<AssignProject> AssignProjects { get; set; } = [];
}
