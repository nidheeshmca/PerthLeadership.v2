using Microsoft.EntityFrameworkCore;
using PerthLeadership.Application.DTOs.Admin;
using PerthLeadership.Application.Interfaces;
using PerthLeadership.Domain.Entities.Admin;
using PerthLeadership.Domain.Exceptions;
using PerthLeadership.Domain.Interfaces;

namespace PerthLeadership.Application.Services;

public sealed class AdminService(
    IRepository<AdminUser> adminRepository,
    IUnitOfWork unitOfWork) : IAdminService
{
    public async Task<AdminUserDto?> GetAdminAsync(int id, CancellationToken cancellationToken = default)
    {
        return await adminRepository.Query()
            .AsNoTracking()
            .Where(a => a.Id == id)
            .Select(a => new AdminUserDto(
                a.Id, a.Login, a.Super, a.Activation, a.LastUpdate))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<AdminUserDto?> VerifyAdminAsync(string login, string password, CancellationToken cancellationToken = default)
    {
        return await adminRepository.Query()
            .AsNoTracking()
            .Where(a => a.Login == login && a.Pass == password && a.Activation == true)
            .Select(a => new AdminUserDto(
                a.Id, a.Login, a.Super, a.Activation, a.LastUpdate))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<AdminUserDto>> GetAllAdminsAsync(CancellationToken cancellationToken = default)
    {
        return await adminRepository.Query()
            .AsNoTracking()
            .Select(a => new AdminUserDto(
                a.Id, a.Login, a.Super, a.Activation, a.LastUpdate))
            .ToListAsync(cancellationToken);
    }

    public async Task<AdminUserDto> CreateAdminAsync(CreateAdminRequest request, CancellationToken cancellationToken = default)
    {
        var exists = await adminRepository.Query()
            .AsNoTracking()
            .AnyAsync(a => a.Login == request.Login, cancellationToken);

        if (exists)
            throw new BusinessRuleViolationException($"Admin user with login '{request.Login}' already exists.");

        var admin = new AdminUser
        {
            Login = request.Login,
            Pass = request.Password,
            Super = request.IsSuper,
            Activation = true,
            LastUpdate = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
        };

        admin = await adminRepository.AddAsync(admin, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new AdminUserDto(admin.Id, admin.Login, admin.Super, admin.Activation, admin.LastUpdate);
    }

    public async Task<AdminUserDto> UpdateAdminAsync(int id, UpdateAdminRequest request, CancellationToken cancellationToken = default)
    {
        var admin = await adminRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(AdminUser), id);

        if (request.Login is not null) admin.Login = request.Login;
        if (request.Password is not null) admin.Pass = request.Password;
        if (request.IsSuper is not null) admin.Super = request.IsSuper;
        if (request.IsActive is not null) admin.Activation = request.IsActive;
        admin.LastUpdate = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

        await adminRepository.UpdateAsync(admin, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new AdminUserDto(admin.Id, admin.Login, admin.Super, admin.Activation, admin.LastUpdate);
    }

    public async Task DeleteAdminAsync(int id, CancellationToken cancellationToken = default)
    {
        var admin = await adminRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(AdminUser), id);

        await adminRepository.DeleteAsync(admin, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<MenuItemDto>> GetMenuItemsAsync(string? userName, CancellationToken cancellationToken = default)
    {
        var menuItems = new List<MenuItemDto>();
        int mid = 1;

        if (userName is null)
        {
            menuItems.Add(new MenuItemDto(mid++, null, 1, "Home", "/"));
            return menuItems;
        }

        var admin = await adminRepository.Query()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Login == userName, cancellationToken);

        if (admin is null)
            return menuItems;

        menuItems.Add(new MenuItemDto(mid++, null, 1, "Home", "/admin"));

        if (admin.Super == true || admin.AdminUsers == true)
            menuItems.Add(new MenuItemDto(mid++, null, 2, "Admin Users", "/admin/users"));

        if (admin.Super == true || admin.TestUser == true)
            menuItems.Add(new MenuItemDto(mid++, null, 3, "Test Users", "/admin/test-users"));

        if (admin.Super == true || admin.Coupons == true)
            menuItems.Add(new MenuItemDto(mid++, null, 4, "Coupons", "/admin/coupons"));

        if (admin.Super == true || admin.AReport == true)
            menuItems.Add(new MenuItemDto(mid++, null, 5, "Reports", "/admin/reports"));

        if (admin.Super == true || admin.DBReports == true)
            menuItems.Add(new MenuItemDto(mid++, null, 6, "DB Reports", "/admin/db-reports"));

        if (admin.Super == true || admin.AStats == true)
            menuItems.Add(new MenuItemDto(mid++, null, 7, "Statistics", "/admin/stats"));

        if (admin.Super == true || admin.TestFOA == true)
            menuItems.Add(new MenuItemDto(mid++, null, 10, "FOA Tests", "/admin/foa/tests"));

        if (admin.Super == true || admin.AReportFOA == true)
            menuItems.Add(new MenuItemDto(mid++, null, 11, "FOA Reports", "/admin/foa/reports"));

        if (admin.Super == true || admin.TestCFOA == true)
            menuItems.Add(new MenuItemDto(mid++, null, 20, "CFOA Tests", "/admin/cfoa/tests"));

        if (admin.Super == true || admin.AReportCFOA == true)
            menuItems.Add(new MenuItemDto(mid++, null, 21, "CFOA Reports", "/admin/cfoa/reports"));

        if (admin.Super == true || admin.TestExoa == true)
            menuItems.Add(new MenuItemDto(mid++, null, 30, "EXOA Tests", "/admin/exoa/tests"));

        if (admin.Super == true || admin.AReportExoa == true)
            menuItems.Add(new MenuItemDto(mid++, null, 31, "EXOA Reports", "/admin/exoa/reports"));

        return menuItems;
    }
}
