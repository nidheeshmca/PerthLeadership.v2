using Microsoft.AspNetCore.Mvc;
using PerthLeadership.Application.DTOs.Client;
using PerthLeadership.Application.Interfaces;

namespace PerthLeadership.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class DocumentsController(IDocumentService documentService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<DocumentDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var document = await documentService.GetByIdAsync(id, cancellationToken);
        return document is null ? NotFound() : Ok(document);
    }

    [HttpGet("by-reference")]
    public async Task<ActionResult<IReadOnlyList<DocumentDto>>> GetByReference(
        [FromQuery] string referenceId, [FromQuery] string referenceType, CancellationToken cancellationToken)
    {
        var documents = await documentService.GetByReferenceAsync(referenceId, referenceType, cancellationToken);
        return Ok(documents);
    }

    [HttpPost("upload")]
    public async Task<ActionResult<DocumentDto>> Upload([FromBody] UploadDocumentRequest request, CancellationToken cancellationToken)
    {
        var document = await documentService.UploadAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = document.Id }, document);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<DocumentDto>> Update(Guid id, [FromBody] UploadDocumentRequest request, CancellationToken cancellationToken)
    {
        var document = await documentService.UpdateAsync(id, request, cancellationToken);
        return Ok(document);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await documentService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpGet("{id:guid}/download")]
    public async Task<IActionResult> Download(Guid id, CancellationToken cancellationToken)
    {
        var document = await documentService.GetByIdAsync(id, cancellationToken);
        if (document is null)
            return NotFound();

        // Note: actual content download would need to load the Content byte[] from the entity.
        // This returns metadata; for the binary stream, a separate infrastructure approach is needed.
        return Ok(document);
    }
}
