namespace PerthLeadership.Domain.Entities.Client;

public class AssignProgram
{
    public int AssignedProgramId { get; set; }
    public int ProgramId { get; set; }
    public int ClientId { get; set; }
    public string Status { get; set; } = null!;
    public DateTime ExpirationDate { get; set; }
    public DateTime AssignedDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public string? Comments { get; set; }
    public bool? IsApproved { get; set; }
    public int OverAllUserId { get; set; }

    // Navigation properties
    public TrainingProgram? TrainingProgram { get; set; }
    public ClientOrganization? ClientOrganization { get; set; }
    public ICollection<AssignProject> AssignProjects { get; set; } = [];
}
