namespace PerthLeadership.Application.DTOs.Client;
public sealed record ProjectDto(
    int ProjectId, string? ProjectName, int? ProgramId,
    DateTime? StartDate, DateTime? EndDate, string? Status);

public sealed record ProjectSummaryDto(
    int ProjectId, string? ProjectName, IReadOnlyList<SubjectDto> Subjects);

public sealed record CreateProjectRequest(
    string ProjectName, int ProgramId, DateTime? StartDate,
    DateTime? EndDate, string? Comments);

public sealed record UpdateProjectRequest(
    string? ProjectName, DateTime? StartDate, DateTime? EndDate,
    string? Status, string? Comments);
