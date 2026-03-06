namespace PerthLeadership.Application.DTOs.Reporting;
public sealed record FoaReportDto(
    int SignatureId, string? ExecutiveSummary, string? SignatureImage,
    string? FinancialMission, string? ValuationTrajectoryImage,
    string? FutureValuation, string? TrajectoryExplanation, string? Summary);

public sealed record FmIntensityResultDto(int? ImageTop, int? ImageLeft);

public sealed record GroupSummaryDto(
    int GroupId, string? GroupName, int MemberCount,
    int? AvgRu, int? AvgVa, IReadOnlyList<GroupMemberDto> Members);

public sealed record GroupMemberDto(
    int UserId, string? UserName, string? Signature);
