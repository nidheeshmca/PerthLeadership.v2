namespace PerthLeadership.Application.Interfaces;
using PerthLeadership.Application.DTOs.Reporting;

public interface IReportService
{
    Task<FoaReportDto?> GetFoaReportAsync(int signatureId, string reportType, string languageCode, CancellationToken cancellationToken = default);
    Task<FmIntensityResultDto?> GetFmIntensityImageAsync(long vaScore, long ruScore, string mode, CancellationToken cancellationToken = default);
    Task<DTOs.Assessment.SignatureDto?> GetSignatureAsync(int sumVa, int sumRu, string assessmentType, CancellationToken cancellationToken = default);
    Task<GroupSummaryDto> GetGroupDistributionSummaryAsync(int groupId, string assessmentType, CancellationToken cancellationToken = default);
}
