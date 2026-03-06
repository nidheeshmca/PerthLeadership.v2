namespace PerthLeadership.Domain.Entities.Client;

public class AssignCoupon
{
    public int CouponAssignedId { get; set; }
    public int? CouponId { get; set; }
    public string? Name { get; set; }
    public int? SubjectId { get; set; }
    public string? Email { get; set; }
    public string? Msg { get; set; }
    public DateTime? SentOn { get; set; }
    public int? SentBy { get; set; }
    public int? Version { get; set; }
    public int? AssignSubjectId { get; set; }
    public string? AssessmentType { get; set; }
    public string? Status { get; set; }
    public DateTime? ConfirmDate { get; set; }
    public DateTime? CompletedDate { get; set; }

    // Navigation properties
    public Coupon? Coupon { get; set; }
    public Subject? Subject { get; set; }
    public AssignSubject? AssignSubject { get; set; }
}
