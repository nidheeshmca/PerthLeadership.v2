using Microsoft.AspNetCore.Mvc;
using PerthLeadership.Application.DTOs.Client;
using PerthLeadership.Application.Interfaces;

namespace PerthLeadership.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProjectsController(IProjectService projectService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProjectDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var project = await projectService.GetByIdAsync(id, cancellationToken);
        return project is null ? NotFound() : Ok(project);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProjectDto>>> GetAll(CancellationToken cancellationToken)
    {
        var projects = await projectService.GetAllAsync(cancellationToken);
        return Ok(projects);
    }

    [HttpGet("by-program/{programId:int}")]
    public async Task<ActionResult<IReadOnlyList<ProjectDto>>> GetByProgramId(int programId, CancellationToken cancellationToken)
    {
        var projects = await projectService.GetByProgramIdAsync(programId, cancellationToken);
        return Ok(projects);
    }

    [HttpGet("by-client/{clientId:int}")]
    public async Task<ActionResult<IReadOnlyList<ProjectDto>>> GetByClientId(int clientId, CancellationToken cancellationToken)
    {
        var projects = await projectService.GetByClientIdAsync(clientId, cancellationToken);
        return Ok(projects);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectDto>> Create([FromBody] CreateProjectRequest request, CancellationToken cancellationToken)
    {
        var project = await projectService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = project.ProjectId }, project);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ProjectDto>> Update(int id, [FromBody] UpdateProjectRequest request, CancellationToken cancellationToken)
    {
        var project = await projectService.UpdateAsync(id, request, cancellationToken);
        return Ok(project);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await projectService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpGet("{id:int}/summary")]
    public async Task<ActionResult<ProjectSummaryDto>> GetSummary(int id, CancellationToken cancellationToken)
    {
        var summary = await projectService.GetProjectSummaryAsync(id, cancellationToken);
        return Ok(summary);
    }
}
