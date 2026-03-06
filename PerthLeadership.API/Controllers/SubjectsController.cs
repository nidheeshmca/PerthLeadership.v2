using Microsoft.AspNetCore.Mvc;
using PerthLeadership.Application.DTOs.Client;
using PerthLeadership.Application.Interfaces;

namespace PerthLeadership.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class SubjectsController(ISubjectService subjectService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<SubjectDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var subject = await subjectService.GetByIdAsync(id, cancellationToken);
        return subject is null ? NotFound() : Ok(subject);
    }

    [HttpGet("by-email")]
    public async Task<ActionResult<SubjectDto>> GetByEmail([FromQuery] string email, CancellationToken cancellationToken)
    {
        var subject = await subjectService.GetByEmailAsync(email, cancellationToken);
        return subject is null ? NotFound() : Ok(subject);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<SubjectDto>>> GetAll(CancellationToken cancellationToken)
    {
        var subjects = await subjectService.GetAllAsync(cancellationToken);
        return Ok(subjects);
    }

    [HttpGet("by-client/{clientId:int}")]
    public async Task<ActionResult<IReadOnlyList<SubjectDto>>> GetByClientId(int clientId, CancellationToken cancellationToken)
    {
        var subjects = await subjectService.GetByClientIdAsync(clientId, cancellationToken);
        return Ok(subjects);
    }

    [HttpGet("unassigned")]
    public async Task<ActionResult<IReadOnlyList<SubjectDto>>> GetUnassigned(CancellationToken cancellationToken)
    {
        var subjects = await subjectService.GetUnassignedAsync(cancellationToken);
        return Ok(subjects);
    }

    [HttpPost]
    public async Task<ActionResult<SubjectDto>> Create([FromBody] CreateSubjectRequest request, CancellationToken cancellationToken)
    {
        var subject = await subjectService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = subject.SubjectId }, subject);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<SubjectDto>> Update(int id, [FromBody] UpdateSubjectRequest request, CancellationToken cancellationToken)
    {
        var subject = await subjectService.UpdateAsync(id, request, cancellationToken);
        return Ok(subject);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await subjectService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpPost("login")]
    public async Task<ActionResult<SubjectDto>> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var subject = await subjectService.ValidateLoginAsync(request.Email, request.Password, cancellationToken);
        return subject is null ? Unauthorized() : Ok(subject);
    }
}

public sealed record LoginRequest(string Email, string Password);
