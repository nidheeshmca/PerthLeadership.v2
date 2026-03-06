using Microsoft.AspNetCore.Mvc;
using PerthLeadership.Application.DTOs.Assessment;
using PerthLeadership.Application.DTOs.Reporting;
using PerthLeadership.Application.Interfaces;

namespace PerthLeadership.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ReportsController(IReportService reportService) : ControllerBase
{
    [HttpGet("foa/{signatureId:int}")]
    public async Task<ActionResult<FoaReportDto>> GetFoaReport(
        int signatureId, [FromQuery] string reportType, [FromQuery] string languageCode, CancellationToken cancellationToken)
    {
        var report = await reportService.GetFoaReportAsync(signatureId, reportType, languageCode, cancellationToken);
        return report is null ? NotFound() : Ok(report);
    }

    [HttpGet("fm-intensity")]
    public async Task<ActionResult<FmIntensityResultDto>> GetFmIntensity(
        [FromQuery] long vaScore, [FromQuery] long ruScore, [FromQuery] string mode, CancellationToken cancellationToken)
    {
        var result = await reportService.GetFmIntensityImageAsync(vaScore, ruScore, mode, cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpGet("signature")]
    public async Task<ActionResult<SignatureDto>> GetSignature(
        [FromQuery] int sumVa, [FromQuery] int sumRu, [FromQuery] string assessmentType, CancellationToken cancellationToken)
    {
        var signature = await reportService.GetSignatureAsync(sumVa, sumRu, assessmentType, cancellationToken);
        return signature is null ? NotFound() : Ok(signature);
    }

    [HttpGet("group-summary/{groupId:int}")]
    public async Task<ActionResult<GroupSummaryDto>> GetGroupSummary(
        int groupId, [FromQuery] string assessmentType, CancellationToken cancellationToken)
    {
        var summary = await reportService.GetGroupDistributionSummaryAsync(groupId, assessmentType, cancellationToken);
        return Ok(summary);
    }
}
