namespace PerthLeadership.Domain.Entities.Client;

public class AssignProject
{
    public int AssignProjectId { get; set; }
    public int ProjectId { get; set; }
    public int? AssignProgramId { get; set; }
    public string? Status { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public DateTime? AssignedDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public string? Comments { get; set; }
    public bool? ViewMessage { get; set; }
    public DateTime? ThankYouLetter { get; set; }
    public DateTime? ReportsGenerated { get; set; }
    public DateTime? ReportsSent { get; set; }
    public DateTime? DeliveryConfirm { get; set; }
    public DateTime? QRAvailable { get; set; }
    public DateTime? ReportBcc { get; set; }
    public bool? PlanRequired { get; set; }
    public string? ReportLocation { get; set; }
    public DateTime? DraftSent { get; set; }
    public DateTime? FinalPlan { get; set; }
    public DateTime? ReportPrinted { get; set; }

    // Navigation properties
    public Project? Project { get; set; }
    public AssignProgram? AssignProgram { get; set; }
    public ICollection<AssignSubject> AssignSubjects { get; set; } = [];
}
