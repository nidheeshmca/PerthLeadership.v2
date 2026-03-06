using Microsoft.AspNetCore.Mvc;
using PerthLeadership.Application.DTOs.Assessment;
using PerthLeadership.Application.Interfaces;

namespace PerthLeadership.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AssessmentsController(IAssessmentService assessmentService) : ControllerBase
{
    [HttpGet("foa/{userId}")]
    public async Task<ActionResult<AssessmentDto>> GetFoaAssessment(string userId, CancellationToken cancellationToken)
    {
        var assessment = await assessmentService.GetFoaAssessmentAsync(userId, cancellationToken);
        return assessment is null ? NotFound() : Ok(assessment);
    }

    [HttpGet("cfoa/{userId}")]
    public async Task<ActionResult<AssessmentDto>> GetCfoaAssessment(string userId, CancellationToken cancellationToken)
    {
        var assessment = await assessmentService.GetCfoaAssessmentAsync(userId, cancellationToken);
        return assessment is null ? NotFound() : Ok(assessment);
    }

    [HttpGet("exoa/{userId}")]
    public async Task<ActionResult<AssessmentDto>> GetExoaAssessment(string userId, CancellationToken cancellationToken)
    {
        var assessment = await assessmentService.GetExoaAssessmentAsync(userId, cancellationToken);
        return assessment is null ? NotFound() : Ok(assessment);
    }

    [HttpGet("ela/{userId}")]
    public async Task<ActionResult<AssessmentDto>> GetElaAssessment(string userId, CancellationToken cancellationToken)
    {
        var assessment = await assessmentService.GetElaAssessmentAsync(userId, cancellationToken);
        return assessment is null ? NotFound() : Ok(assessment);
    }

    [HttpPost("start")]
    public async Task<ActionResult<AssessmentDto>> Start([FromBody] StartAssessmentRequest request, CancellationToken cancellationToken)
    {
        var assessment = await assessmentService.StartAssessmentAsync(request, cancellationToken);
        return CreatedAtAction(null, assessment);
    }

    [HttpPost("submit-answer")]
    public async Task<IActionResult> SubmitAnswer([FromBody] SubmitAnswerRequest request, CancellationToken cancellationToken)
    {
        await assessmentService.SubmitAnswerAsync(request, cancellationToken);
        return Ok();
    }

    [HttpPost("complete")]
    public async Task<ActionResult<AssessmentResultDto>> Complete([FromBody] CompleteAssessmentRequest request, CancellationToken cancellationToken)
    {
        var result = await assessmentService.CompleteAssessmentAsync(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("questions")]
    public async Task<ActionResult<IReadOnlyList<QuestionDto>>> GetQuestions(
        [FromQuery] string assessmentType, [FromQuery] int? version, CancellationToken cancellationToken)
    {
        var questions = await assessmentService.GetQuestionsAsync(assessmentType, version, cancellationToken);
        return Ok(questions);
    }

    [HttpGet("status/{userId}")]
    public async Task<ActionResult<AssessmentStatusDto>> GetStatus(
        string userId, [FromQuery] string assessmentType, CancellationToken cancellationToken)
    {
        var status = await assessmentService.GetUserStatusAsync(userId, assessmentType, cancellationToken);
        return Ok(status);
    }
}
