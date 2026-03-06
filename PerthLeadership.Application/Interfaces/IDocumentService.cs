namespace PerthLeadership.Application.Interfaces;
using PerthLeadership.Application.DTOs.Client;

public interface IDocumentService
{
    Task<DocumentDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<DocumentDto>> GetByReferenceAsync(string referenceId, string referenceType, CancellationToken cancellationToken = default);
    Task<DocumentDto> UploadAsync(UploadDocumentRequest request, CancellationToken cancellationToken = default);
    Task<DocumentDto> UpdateAsync(int id, UploadDocumentRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
