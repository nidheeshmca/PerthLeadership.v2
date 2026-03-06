namespace PerthLeadership.Application.DTOs.Client;
public sealed record CouponDto(
    int CouponId, string? CouponNo, string? CouponType, int? DaysToExpire,
    DateTime? CreatedDate, int? ClientId, string? Series, string? AssessmentType,
    short? CouponLimit, DateTime? DueDate, bool? UserReport);

public sealed record CreateCouponRequest(
    string? CouponNo, string CouponType, int DaysToExpire,
    int ClientId, int? LicenseeId, int? CreatorId, string? Series,
    string? Comments, short? CouponLimit, int? ProjectId,
    string AssessmentType, bool? UserReport, DateTime? DueDate);

public sealed record UpdateCouponRequest(
    string? CouponType, int? DaysToExpire, string? Series,
    string? Comments, short? CouponLimit, string? AssessmentType,
    bool? UserReport, DateTime? DueDate);

public sealed record AssignCouponRequest(
    int CouponId, int SubjectId, string? Email, string? Name,
    string? Message, string AssessmentType, int? AssignSubjectId, int? Version);
