using Microsoft.AspNetCore.Mvc;
using PerthLeadership.Application.DTOs.Admin;
using PerthLeadership.Application.Interfaces;

namespace PerthLeadership.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AdminController(IAdminService adminService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AdminUserDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var admin = await adminService.GetAdminAsync(id, cancellationToken);
        return admin is null ? NotFound() : Ok(admin);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<AdminUserDto>>> GetAll(CancellationToken cancellationToken)
    {
        var admins = await adminService.GetAllAdminsAsync(cancellationToken);
        return Ok(admins);
    }

    [HttpPost("verify")]
    public async Task<ActionResult<AdminUserDto>> Verify([FromBody] AdminLoginRequest request, CancellationToken cancellationToken)
    {
        var admin = await adminService.VerifyAdminAsync(request.Login, request.Password, cancellationToken);
        return admin is null ? Unauthorized() : Ok(admin);
    }

    [HttpPost]
    public async Task<ActionResult<AdminUserDto>> Create([FromBody] CreateAdminRequest request, CancellationToken cancellationToken)
    {
        var admin = await adminService.CreateAdminAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = admin.Id }, admin);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<AdminUserDto>> Update(Guid id, [FromBody] UpdateAdminRequest request, CancellationToken cancellationToken)
    {
        var admin = await adminService.UpdateAdminAsync(id, request, cancellationToken);
        return Ok(admin);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await adminService.DeleteAdminAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpGet("menu")]
    public async Task<ActionResult<IReadOnlyList<MenuItemDto>>> GetMenu([FromQuery] string? userName, CancellationToken cancellationToken)
    {
        var menuItems = await adminService.GetMenuItemsAsync(userName, cancellationToken);
        return Ok(menuItems);
    }
}

public sealed record AdminLoginRequest(string Login, string Password);
