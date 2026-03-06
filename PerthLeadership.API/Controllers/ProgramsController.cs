using Microsoft.AspNetCore.Mvc;
using PerthLeadership.Application.DTOs.Client;
using PerthLeadership.Application.Interfaces;

namespace PerthLeadership.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProgramsController(IProgramService programService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProgramDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var program = await programService.GetByIdAsync(id, cancellationToken);
        return program is null ? NotFound() : Ok(program);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProgramDto>>> GetAll(CancellationToken cancellationToken)
    {
        var programs = await programService.GetAllAsync(cancellationToken);
        return Ok(programs);
    }

    [HttpGet("by-client/{clientId:int}")]
    public async Task<ActionResult<IReadOnlyList<ProgramDto>>> GetByClientId(int clientId, CancellationToken cancellationToken)
    {
        var programs = await programService.GetByClientIdAsync(clientId, cancellationToken);
        return Ok(programs);
    }

    [HttpPost]
    public async Task<ActionResult<ProgramDto>> Create([FromBody] CreateProgramRequest request, CancellationToken cancellationToken)
    {
        var program = await programService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = program.ProgramId }, program);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ProgramDto>> Update(int id, [FromBody] UpdateProgramRequest request, CancellationToken cancellationToken)
    {
        var program = await programService.UpdateAsync(id, request, cancellationToken);
        return Ok(program);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await programService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
