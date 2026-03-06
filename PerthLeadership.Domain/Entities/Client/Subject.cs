namespace PerthLeadership.Domain.Entities.Client;

public class Subject
{
    public int SubjectId { get; set; }
    public long? PID { get; set; }
    public string? Salutation { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public DateTime? AsstBeginDate { get; set; }
    public DateTime? AsstEndDate { get; set; }
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    public string? Country { get; set; }
    public string? Website { get; set; }
    public string? Phone1 { get; set; }
    public string? Phone2 { get; set; }
    public int? ClientId { get; set; }
    public string? Dept { get; set; }
    public string? Designation { get; set; }
    public string? PositionLevel { get; set; }
    public string? Gender { get; set; }
    public string? Age { get; set; }
    public string? Education { get; set; }
    public string? AreaEndeavor { get; set; }
    public string? Experience { get; set; }
    public string? Industry { get; set; }
    public string? SizeRevenue { get; set; }
    public string? OrganizationSize { get; set; }
    public int? OverallUserId { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? CreatedBy { get; set; }
    public string? FinancialMission { get; set; }
    public int? ObsProf { get; set; }
    public int? ObsLead { get; set; }
    public int? ObsManage { get; set; }
    public int? ObsMission { get; set; }
    public int? FmIntensityVAMid { get; set; }
    public int? FmIntensityRUMid { get; set; }
    public string? FMIntensityImage { get; set; }
    public bool? NewPassword { get; set; }
    public bool? ViewRelease { get; set; }
    public string? Organization { get; set; }
    public string? UserType { get; set; }
    public int? LanguageId { get; set; }

    // Navigation properties
    public OverAllUser? OverAllUser { get; set; }
    public ClientOrganization? ClientOrganization { get; set; }
    public ICollection<AssignSubject> AssignSubjects { get; set; } = [];
    public ICollection<AssignCoupon> AssignCoupons { get; set; } = [];
}
