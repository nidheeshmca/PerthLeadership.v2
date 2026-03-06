namespace PerthLeadership.Application.DTOs.Admin;
public sealed record AdminUserDto(
    int Id, string? Login, bool? IsSuper, bool? IsActive, string? LastUpdate);

public sealed record CreateAdminRequest(string Login, string Password, bool? IsSuper);
public sealed record UpdateAdminRequest(string? Login, string? Password, bool? IsSuper, bool? IsActive);
public sealed record MenuItemDto(int Mid, int? Parent, int? Sequence, string? Name, string? Link);
