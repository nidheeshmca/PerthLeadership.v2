namespace PerthLeadership.Application.Interfaces;
using PerthLeadership.Application.DTOs.Client;

public interface IClientService
{
    Task<ClientDto?> GetByIdAsync(int clientId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<ClientDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ClientDto> CreateAsync(CreateClientRequest request, CancellationToken cancellationToken = default);
    Task<ClientDto> UpdateAsync(int clientId, UpdateClientRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int clientId, CancellationToken cancellationToken = default);
    Task<ClientDetailDto?> GetDetailAsync(int clientId, CancellationToken cancellationToken = default);
}
