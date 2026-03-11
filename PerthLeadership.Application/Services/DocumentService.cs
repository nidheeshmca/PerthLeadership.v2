using Microsoft.EntityFrameworkCore;
using PerthLeadership.Application.DTOs.Client;
using PerthLeadership.Application.Interfaces;
using PerthLeadership.Domain.Entities.Document;
using PerthLeadership.Domain.Exceptions;
using PerthLeadership.Domain.Interfaces;

namespace PerthLeadership.Application.Services;

public sealed class DocumentService(
    IRepository<AttachedDocument> documentRepository,
    IUnitOfWork unitOfWork) : IDocumentService
{
    public async Task<DocumentDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await documentRepository.Query()
            .AsNoTracking()
            .Where(d => d.Id == id)
            .Select(d => new DocumentDto(
                d.Id, d.ReferenceId, d.ReferenceType,
                d.SavedDate, d.Title, d.DocumentName,
                d.ContentType, d.Description))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<DocumentDto>> GetByReferenceAsync(string referenceId, string referenceType, CancellationToken cancellationToken = default)
    {
        return await documentRepository.Query()
            .AsNoTracking()
            .Where(d => d.ReferenceId == referenceId && d.ReferenceType == referenceType)
            .OrderByDescending(d => d.SavedDate)
            .Select(d => new DocumentDto(
                d.Id, d.ReferenceId, d.ReferenceType,
                d.SavedDate, d.Title, d.DocumentName,
                d.ContentType, d.Description))
            .ToListAsync(cancellationToken);
    }

    public async Task<DocumentDto> UploadAsync(UploadDocumentRequest request, CancellationToken cancellationToken = default)
    {
        var document = new AttachedDocument
        {
            ReferenceId = request.ReferenceId,
            ReferenceType = request.ReferenceType,
            Title = request.Title,
            DocumentName = request.DocumentName,
            Content = request.Content,
            ContentType = request.ContentType,
            Description = request.Description,
            SavedDate = DateTime.UtcNow
        };

        document = await documentRepository.AddAsync(document, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new DocumentDto(
            document.Id, document.ReferenceId, document.ReferenceType,
            document.SavedDate, document.Title, document.DocumentName,
            document.ContentType, document.Description);
    }

    public async Task<DocumentDto> UpdateAsync(Guid id, UploadDocumentRequest request, CancellationToken cancellationToken = default)
    {
        var document = await documentRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(AttachedDocument), id);

        document.ReferenceId = request.ReferenceId;
        document.ReferenceType = request.ReferenceType;
        document.Title = request.Title;
        document.DocumentName = request.DocumentName;
        document.Content = request.Content;
        document.ContentType = request.ContentType;
        document.Description = request.Description;
        document.SavedDate = DateTime.UtcNow;

        await documentRepository.UpdateAsync(document, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new DocumentDto(
            document.Id, document.ReferenceId, document.ReferenceType,
            document.SavedDate, document.Title, document.DocumentName,
            document.ContentType, document.Description);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var document = await documentRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(AttachedDocument), id);

        await documentRepository.DeleteAsync(document, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
