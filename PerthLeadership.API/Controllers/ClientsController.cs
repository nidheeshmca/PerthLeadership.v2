using Microsoft.AspNetCore.Mvc;
using PerthLeadership.Application.DTOs.Client;
using PerthLeadership.Application.Interfaces;

namespace PerthLeadership.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ClientsController(IClientService clientService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ClientDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var client = await clientService.GetByIdAsync(id, cancellationToken);
        return client is null ? NotFound() : Ok(client);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ClientDto>>> GetAll(CancellationToken cancellationToken)
    {
        var clients = await clientService.GetAllAsync(cancellationToken);
        return Ok(clients);
    }

    [HttpPost]
    public async Task<ActionResult<ClientDto>> Create([FromBody] CreateClientRequest request, CancellationToken cancellationToken)
    {
        var client = await clientService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = client.ClientId }, client);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ClientDto>> Update(int id, [FromBody] UpdateClientRequest request, CancellationToken cancellationToken)
    {
        var client = await clientService.UpdateAsync(id, request, cancellationToken);
        return Ok(client);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await clientService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpGet("{id:int}/detail")]
    public async Task<ActionResult<ClientDetailDto>> GetDetail(int id, CancellationToken cancellationToken)
    {
        var detail = await clientService.GetDetailAsync(id, cancellationToken);
        return detail is null ? NotFound() : Ok(detail);
    }
}
