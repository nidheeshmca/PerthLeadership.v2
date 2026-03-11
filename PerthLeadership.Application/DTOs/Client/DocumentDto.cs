namespace PerthLeadership.Application.DTOs.Client;
public sealed record DocumentDto(
    Guid Id, string? ReferenceId, string? ReferenceType,
    DateTime? SavedDate, string? Title, string? DocumentName,
    string? ContentType, string? Description);

public sealed record UploadDocumentRequest(
    string ReferenceId, string ReferenceType, string Title,
    string DocumentName, byte[] Content, string ContentType, string? Description);
