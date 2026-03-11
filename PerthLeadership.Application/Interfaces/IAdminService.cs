namespace PerthLeadership.Application.Interfaces;
using PerthLeadership.Application.DTOs.Admin;

public interface IAdminService
{
    Task<AdminUserDto?> GetAdminAsync(Guid id, CancellationToken cancellationToken = default);
    Task<AdminUserDto?> VerifyAdminAsync(string login, string password, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<AdminUserDto>> GetAllAdminsAsync(CancellationToken cancellationToken = default);
    Task<AdminUserDto> CreateAdminAsync(CreateAdminRequest request, CancellationToken cancellationToken = default);
    Task<AdminUserDto> UpdateAdminAsync(Guid id, UpdateAdminRequest request, CancellationToken cancellationToken = default);
    Task DeleteAdminAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<MenuItemDto>> GetMenuItemsAsync(string? userName, CancellationToken cancellationToken = default);
}
