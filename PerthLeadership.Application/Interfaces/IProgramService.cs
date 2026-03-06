namespace PerthLeadership.Application.Interfaces;
using PerthLeadership.Application.DTOs.Client;

public interface IProgramService
{
    Task<ProgramDto?> GetByIdAsync(int programId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ProgramDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ProgramDto>> GetByClientIdAsync(int clientId, CancellationToken cancellationToken = default);
    Task<ProgramDto> CreateAsync(CreateProgramRequest request, CancellationToken cancellationToken = default);
    Task<ProgramDto> UpdateAsync(int programId, UpdateProgramRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int programId, CancellationToken cancellationToken = default);
}
