namespace PerthLeadership.Application.DTOs.Client;
public sealed record ProgramDto(
    int ProgramId, string? ProgramName, string? Description,
    DateTime? CreatedDate, string? Status);

public sealed record CreateProgramRequest(string ProgramName, string? Description);
public sealed record UpdateProgramRequest(string? ProgramName, string? Description, string? Status);
