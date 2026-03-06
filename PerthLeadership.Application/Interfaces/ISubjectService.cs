namespace PerthLeadership.Application.Interfaces;
using PerthLeadership.Application.DTOs.Client;

public interface ISubjectService
{
    Task<SubjectDto?> GetByIdAsync(int subjectId, CancellationToken cancellationToken = default);
    Task<SubjectDto?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<SubjectDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<SubjectDto>> GetByClientIdAsync(int clientId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<SubjectDto>> GetUnassignedAsync(CancellationToken cancellationToken = default);
    Task<SubjectDto> CreateAsync(CreateSubjectRequest request, CancellationToken cancellationToken = default);
    Task<SubjectDto> UpdateAsync(int subjectId, UpdateSubjectRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int subjectId, CancellationToken cancellationToken = default);
    Task<SubjectDto?> ValidateLoginAsync(string email, string password, CancellationToken cancellationToken = default);
}
