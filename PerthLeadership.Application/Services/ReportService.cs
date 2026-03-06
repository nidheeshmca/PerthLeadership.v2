using Microsoft.EntityFrameworkCore;
using PerthLeadership.Application.DTOs.Assessment;
using PerthLeadership.Application.DTOs.Reporting;
using PerthLeadership.Application.Interfaces;
using PerthLeadership.Domain.Entities.Assessment;
using PerthLeadership.Domain.Exceptions;
using PerthLeadership.Domain.Interfaces;

namespace PerthLeadership.Application.Services;

public sealed class ReportService(
    IRepository<AssessmentSignature> signatureRepository,
    IRepository<ImageSetting> imageSettingRepository,
    IRepository<PercentAssignment> percentRepository,
    IRepository<AssessmentGroup> groupRepository,
    IRepository<AssessmentUserGroup> userGroupRepository,
    IRepository<FoaAssessment> foaRepository,
    IRepository<CfoaAssessment> cfoaRepository) : IReportService
{
    public async Task<FoaReportDto?> GetFoaReportAsync(int signatureId, string reportType, string languageCode, CancellationToken cancellationToken = default)
    {
        var signature = await signatureRepository.Query()
            .AsNoTracking()
            .Where(s => s.SignatureId == signatureId && s.AssessmentType == reportType)
            .FirstOrDefaultAsync(cancellationToken);

        if (signature is null)
            return null;

        return new FoaReportDto(
            signatureId,
            signature.ValuationOutcome,
            signature.GraphImage,
            signature.MissionImage,
            signature.GraphImage,
            signature.ValuationOutcome,
            signature.ValuationOutcome,
            signature.Signature);
    }

    public async Task<FmIntensityResultDto?> GetFmIntensityImageAsync(long vaScore, long ruScore, string mode, CancellationToken cancellationToken = default)
    {
        // Replaces Sp_getFmIntensityImage stored procedure
        var vaCategory = await percentRepository.Query()
            .AsNoTracking()
            .Where(p => p.AssessmentType == mode
                && p.ScoreType == "VA"
                && p.LowerBound <= vaScore
                && p.UpperBound >= vaScore)
            .Select(p => p.CategoryId)
            .FirstOrDefaultAsync(cancellationToken);

        var ruCategory = await percentRepository.Query()
            .AsNoTracking()
            .Where(p => p.AssessmentType == mode
                && p.ScoreType == "RU"
                && p.LowerBound <= ruScore
                && p.UpperBound >= ruScore)
            .Select(p => p.CategoryId)
            .FirstOrDefaultAsync(cancellationToken);

        if (vaCategory is null || ruCategory is null)
            return null;

        var imageSetting = await imageSettingRepository.Query()
            .AsNoTracking()
            .Where(i => i.AssessmentType == mode
                && i.VACategoryId == vaCategory
                && i.RUCategoryId == ruCategory)
            .FirstOrDefaultAsync(cancellationToken);

        if (imageSetting is null)
            return null;

        return new FmIntensityResultDto(imageSetting.ImageTop, imageSetting.ImageLeft);
    }

    public async Task<SignatureDto?> GetSignatureAsync(int sumVa, int sumRu, string assessmentType, CancellationToken cancellationToken = default)
    {
        // Replaces SP_FORAGETIMAGE / SP_CFORAGETIMAGE stored procedures
        var vaCategory = await percentRepository.Query()
            .AsNoTracking()
            .Where(p => p.AssessmentType == assessmentType
                && p.ScoreType == "VA"
                && p.LowerBound <= sumVa
                && p.UpperBound >= sumVa)
            .Select(p => p.CategoryId)
            .FirstOrDefaultAsync(cancellationToken);

        var ruCategory = await percentRepository.Query()
            .AsNoTracking()
            .Where(p => p.AssessmentType == assessmentType
                && p.ScoreType == "RU"
                && p.LowerBound <= sumRu
                && p.UpperBound >= sumRu)
            .Select(p => p.CategoryId)
            .FirstOrDefaultAsync(cancellationToken);

        if (vaCategory is null || ruCategory is null)
            return null;

        var signature = await signatureRepository.Query()
            .AsNoTracking()
            .Where(s => s.AssessmentType == assessmentType
                && s.VACategoryId == (byte)vaCategory
                && s.RUCategoryId == (byte)ruCategory)
            .FirstOrDefaultAsync(cancellationToken);

        if (signature is null)
            return null;

        return new SignatureDto(
            signature.Signature,
            signature.ValuationOutcome,
            signature.MissionImage,
            signature.GraphImage);
    }

    public async Task<GroupSummaryDto> GetGroupDistributionSummaryAsync(int groupId, string assessmentType, CancellationToken cancellationToken = default)
    {
        var group = await groupRepository.Query()
            .AsNoTracking()
            .Where(g => g.GroupId == groupId && g.AssessmentType == assessmentType)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException(nameof(AssessmentGroup), groupId);

        var userGroups = await userGroupRepository.Query()
            .AsNoTracking()
            .Where(ug => ug.GroupId == groupId)
            .ToListAsync(cancellationToken);

        var members = new List<GroupMemberDto>();

        foreach (var ug in userGroups)
        {
            string? userName = null;
            string? signature = null;

            if (assessmentType.Equals("FOA", StringComparison.OrdinalIgnoreCase)
                || assessmentType.Equals("CFOA", StringComparison.OrdinalIgnoreCase))
            {
                var foaAssessment = assessmentType.Equals("FOA", StringComparison.OrdinalIgnoreCase)
                    ? await foaRepository.Query()
                        .AsNoTracking()
                        .Where(a => a.UserId == ug.UserId.ToString())
                        .OrderByDescending(a => a.StartDate)
                        .FirstOrDefaultAsync(cancellationToken)
                    : null;

                var cfoaAssessment = assessmentType.Equals("CFOA", StringComparison.OrdinalIgnoreCase)
                    ? await cfoaRepository.Query()
                        .AsNoTracking()
                        .Where(a => a.UserId == ug.UserId.ToString())
                        .OrderByDescending(a => a.StartDate)
                        .FirstOrDefaultAsync(cancellationToken)
                    : null;

                userName = foaAssessment?.CompanyName ?? cfoaAssessment?.CompanyName;
                signature = foaAssessment?.Signature ?? cfoaAssessment?.Signature;
            }

            members.Add(new GroupMemberDto(ug.UserId, userName, signature));
        }

        return new GroupSummaryDto(
            group.GroupId, group.GroupName, members.Count,
            group.AvgRU, group.AvgVA, members);
    }
}
