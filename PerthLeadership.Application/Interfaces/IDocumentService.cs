namespace PerthLeadership.Application.Interfaces;
using PerthLeadership.Application.DTOs.Client;

public interface IDocumentService
{
    Task<DocumentDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<DocumentDto>> GetByReferenceAsync(string referenceId, string referenceType, CancellationToken cancellationToken = default);
    Task<DocumentDto> UploadAsync(UploadDocumentRequest request, CancellationToken cancellationToken = default);
    Task<DocumentDto> UpdateAsync(Guid id, UploadDocumentRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
