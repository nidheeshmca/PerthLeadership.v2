using PerthLeadership.Domain.Common;

namespace PerthLeadership.Domain.Entities.Admin;

public class AdminUser : EntityBase
{
    public string? Login { get; set; }
    public string? Pass { get; set; }
    public bool? Super { get; set; }
    public bool? Activation { get; set; }
    public bool? AdminUsers { get; set; }
    public bool? TestUser { get; set; }
    public bool? NewTest { get; set; }
    public bool? Test { get; set; }
    public bool? AReport { get; set; }
    public bool? DBReports { get; set; }
    public bool? FeedBack { get; set; }
    public bool? Terms { get; set; }
    public bool? Coupons { get; set; }
    public bool? AStats { get; set; }
    public bool? PayAmt { get; set; }
    public bool? EList { get; set; }
    public string? LastUpdate { get; set; }
    public bool? Home { get; set; }
    public bool? PayAmtExoa { get; set; }
    public bool? TestUserExoa { get; set; }
    public bool? NewTestExoa { get; set; }
    public bool? TestExoa { get; set; }
    public bool? AReportExoa { get; set; }
    public bool? DBReportsExoa { get; set; }
    public bool? FeedBackExoa { get; set; }
    public bool? AStatsExoa { get; set; }
    public bool? PayAmtFOA { get; set; }
    public bool? TestUserFOA { get; set; }
    public bool? NewTestFOA { get; set; }
    public bool? TestFOA { get; set; }
    public bool? AReportFOA { get; set; }
    public bool? DBReportsFOA { get; set; }
    public bool? AStatsFOA { get; set; }
    public bool? PercentageFOA { get; set; }
    public bool? FeedBackFOA { get; set; }
    public bool? PayAmCFOA { get; set; }
    public bool? DBReportsCFOA { get; set; }
    public bool? NewTestCFOA { get; set; }
    public bool? AStatsCFOA { get; set; }
    public bool? TestCFOA { get; set; }
    public bool? AReportCFOA { get; set; }
    public bool? TestUserCFOA { get; set; }
    public bool? FeedBackCFOA { get; set; }
    public bool? PercentageFOA1 { get; set; }
    public bool? PercentageCFOA { get; set; }
    public bool? TestUserSummary { get; set; }
    public bool? TestMRI { get; set; }
}
