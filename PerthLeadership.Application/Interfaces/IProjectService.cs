namespace PerthLeadership.Application.Interfaces;
using PerthLeadership.Application.DTOs.Client;

public interface IProjectService
{
    Task<ProjectDto?> GetByIdAsync(int projectId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ProjectDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ProjectDto>> GetByProgramIdAsync(int programId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ProjectDto>> GetByClientIdAsync(int clientId, CancellationToken cancellationToken = default);
    Task<ProjectDto> CreateAsync(CreateProjectRequest request, CancellationToken cancellationToken = default);
    Task<ProjectDto> UpdateAsync(int projectId, UpdateProjectRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int projectId, CancellationToken cancellationToken = default);
    Task<ProjectSummaryDto> GetProjectSummaryAsync(int projectId, CancellationToken cancellationToken = default);
}
