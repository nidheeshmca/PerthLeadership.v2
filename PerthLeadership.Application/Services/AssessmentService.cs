using Microsoft.EntityFrameworkCore;
using PerthLeadership.Application.DTOs.Assessment;
using PerthLeadership.Application.Interfaces;
using PerthLeadership.Domain.Entities.Assessment;
using PerthLeadership.Domain.Exceptions;
using PerthLeadership.Domain.Interfaces;

namespace PerthLeadership.Application.Services;

public sealed class AssessmentService(
    IRepository<FoaAssessment> foaRepository,
    IRepository<FoaResult> foaResultRepository,
    IRepository<FoaQuestion> foaQuestionRepository,
    IRepository<FoaQuestionV2> foaQuestionV2Repository,
    IRepository<CfoaAssessment> cfoaRepository,
    IRepository<CfoaResult> cfoaResultRepository,
    IRepository<CfoaQuestion> cfoaQuestionRepository,
    IRepository<ExoaAssessment> exoaRepository,
    IRepository<ExoaResult> exoaResultRepository,
    IRepository<ExoaQuestion> exoaQuestionRepository,
    IRepository<ElaAssessment> elaRepository,
    IRepository<ElaResult> elaResultRepository,
    IRepository<AssessmentSignature> signatureRepository,
    IRepository<PercentAssignment> percentRepository,
    IUnitOfWork unitOfWork) : IAssessmentService
{
    public async Task<AssessmentDto?> GetFoaAssessmentAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await foaRepository.Query()
            .AsNoTracking()
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.StartDate)
            .Select(a => new AssessmentDto(
                a.Id, a.UserId, "FOA",
                a.StartDate, a.CompletionDate,
                a.TestStatus.HasValue ? a.TestStatus.Value.ToString() : null,
                a.SumVA, a.SumRU, a.Signature, a.CompanyName))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<AssessmentDto?> GetCfoaAssessmentAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await cfoaRepository.Query()
            .AsNoTracking()
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.StartDate)
            .Select(a => new AssessmentDto(
                a.Id, a.UserId, "CFOA",
                a.StartDate, a.CompletionDate,
                a.TestStatus.HasValue ? a.TestStatus.Value.ToString() : null,
                a.SumVA, a.SumRU, a.Signature, a.CompanyName))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<AssessmentDto?> GetExoaAssessmentAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await exoaRepository.Query()
            .AsNoTracking()
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.StartDate)
            .Select(a => new AssessmentDto(
                a.Id, a.UserId, "EXOA",
                a.StartDate, a.CompletionDate,
                a.TestStatus, null, null, null, a.CompanyName))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<AssessmentDto?> GetElaAssessmentAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await elaRepository.Query()
            .AsNoTracking()
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.StartDate)
            .Select(a => new AssessmentDto(
                a.Id, a.UserId, "ELA",
                a.StartDate, a.CompletionDate,
                a.TestStatus, null, null, null, null))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<AssessmentDto> StartAssessmentAsync(StartAssessmentRequest request, CancellationToken cancellationToken = default)
    {
        var assessmentType = request.AssessmentType.ToUpperInvariant();

        return assessmentType switch
        {
            "FOA" => await StartFoaAssessmentAsync(request, cancellationToken),
            "CFOA" => await StartCfoaAssessmentAsync(request, cancellationToken),
            "EXOA" => await StartExoaAssessmentAsync(request, cancellationToken),
            "ELA" => await StartElaAssessmentAsync(request, cancellationToken),
            _ => throw new BusinessRuleViolationException($"Unknown assessment type: {assessmentType}")
        };
    }

    public async Task SubmitAnswerAsync(SubmitAnswerRequest request, CancellationToken cancellationToken = default)
    {
        var assessmentType = request.AssessmentType.ToUpperInvariant();

        switch (assessmentType)
        {
            case "FOA":
                await SubmitFoaAnswerAsync(request, cancellationToken);
                break;
            case "CFOA":
                await SubmitCfoaAnswerAsync(request, cancellationToken);
                break;
            case "EXOA":
                await SubmitExoaAnswerAsync(request, cancellationToken);
                break;
            case "ELA":
                await SubmitElaAnswerAsync(request, cancellationToken);
                break;
            default:
                throw new BusinessRuleViolationException($"Unknown assessment type: {assessmentType}");
        }
    }

    public async Task<AssessmentResultDto> CompleteAssessmentAsync(CompleteAssessmentRequest request, CancellationToken cancellationToken = default)
    {
        var assessmentType = request.AssessmentType.ToUpperInvariant();

        return assessmentType switch
        {
            "FOA" => await CompleteFoaAssessmentAsync(request, cancellationToken),
            "CFOA" => await CompleteCfoaAssessmentAsync(request, cancellationToken),
            "EXOA" => await CompleteExoaAssessmentAsync(request, cancellationToken),
            "ELA" => await CompleteElaAssessmentAsync(request, cancellationToken),
            _ => throw new BusinessRuleViolationException($"Unknown assessment type: {assessmentType}")
        };
    }

    public async Task<IReadOnlyList<QuestionDto>> GetQuestionsAsync(string assessmentType, int? version, CancellationToken cancellationToken = default)
    {
        var type = assessmentType.ToUpperInvariant();

        return type switch
        {
            "FOA" when version is > 1 => await foaQuestionV2Repository.Query()
                .AsNoTracking()
                .Where(q => q.Version == version)
                .Select(q => new QuestionDto(q.Id, q.Question, q.QA, q.QB, q.Type, q.IsGenuine, q.Category))
                .ToListAsync(cancellationToken),
            "FOA" => await foaQuestionRepository.Query()
                .AsNoTracking()
                .Select(q => new QuestionDto(q.Id, q.Question, q.QA, q.QB, q.Type, q.IsGenuine, q.Category))
                .ToListAsync(cancellationToken),
            "CFOA" => await cfoaQuestionRepository.Query()
                .AsNoTracking()
                .Select(q => new QuestionDto(q.Id, q.Question, q.QA, q.QB, q.Type, q.IsGenuine, q.Category))
                .ToListAsync(cancellationToken),
            "EXOA" => await exoaQuestionRepository.Query()
                .AsNoTracking()
                .Select(q => new QuestionDto(q.Id, q.Question, q.AnsLeft, q.AnsRight,
                    q.Type.HasValue ? q.Type.Value.ToString() : null, null, null))
                .ToListAsync(cancellationToken),
            _ => throw new BusinessRuleViolationException($"Unknown assessment type: {type}")
        };
    }

    public async Task<AssessmentStatusDto> GetUserStatusAsync(string userId, string assessmentType, CancellationToken cancellationToken = default)
    {
        var type = assessmentType.ToUpperInvariant();

        return type switch
        {
            "FOA" => await GetFoaStatusAsync(userId, cancellationToken),
            "CFOA" => await GetCfoaStatusAsync(userId, cancellationToken),
            "EXOA" => await GetExoaStatusAsync(userId, cancellationToken),
            "ELA" => await GetElaStatusAsync(userId, cancellationToken),
            _ => throw new BusinessRuleViolationException($"Unknown assessment type: {type}")
        };
    }

    // --- FOA helpers ---

    private async Task<AssessmentDto> StartFoaAssessmentAsync(StartAssessmentRequest request, CancellationToken cancellationToken)
    {
        var existing = await foaRepository.Query()
            .AsNoTracking()
            .Where(a => a.UserId == request.UserId && a.CompletionDate != null)
            .AnyAsync(cancellationToken);

        if (existing)
            throw new AssessmentAlreadyCompletedException($"User '{request.UserId}' has already completed FOA assessment.");

        var assessment = new FoaAssessment
        {
            UserId = request.UserId,
            StartDate = DateTime.UtcNow,
            CompanyName = request.CompanyName,
            TestStatus = 0,
            Cnt = 0
        };

        assessment = await foaRepository.AddAsync(assessment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new AssessmentDto(assessment.Id, assessment.UserId, "FOA",
            assessment.StartDate, null, "0", null, null, null, assessment.CompanyName);
    }

    private async Task SubmitFoaAnswerAsync(SubmitAnswerRequest request, CancellationToken cancellationToken)
    {
        var assessment = await foaRepository.Query()
            .Where(a => a.UserId == request.UserId && a.CompletionDate == null)
            .OrderByDescending(a => a.StartDate)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException("Active FOA assessment not found for user.");

        var result = new FoaResult
        {
            PID = assessment.PID,
            UserId = request.UserId,
            Question = request.QuestionNumber,
            Answer = request.Answer,
            Rating = request.Rating,
            EnterDate = DateTime.UtcNow
        };

        await foaResultRepository.AddAsync(result, cancellationToken);
        assessment.Cnt = (assessment.Cnt ?? 0) + 1;
        await foaRepository.UpdateAsync(assessment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private async Task<AssessmentResultDto> CompleteFoaAssessmentAsync(CompleteAssessmentRequest request, CancellationToken cancellationToken)
    {
        var assessment = await foaRepository.Query()
            .Where(a => a.UserId == request.UserId && a.CompletionDate == null)
            .OrderByDescending(a => a.StartDate)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException("Active FOA assessment not found for user.");

        // Calculate scores from results
        var results = await foaResultRepository.Query()
            .AsNoTracking()
            .Where(r => r.UserId == request.UserId)
            .ToListAsync(cancellationToken);

        var sumVa = results.Where(r => r.Rating.HasValue).Sum(r => r.Rating!.Value);
        var sumRu = results.Count > 0 ? results.Count * 5 - sumVa : 0;

        // Look up signature based on scores
        var vaCategory = await GetCategoryIdAsync("FOA", "VA", sumVa, cancellationToken);
        var ruCategory = await GetCategoryIdAsync("FOA", "RU", sumRu, cancellationToken);

        var signature = await signatureRepository.Query()
            .AsNoTracking()
            .Where(s => s.AssessmentType == "FOA"
                && s.VACategoryId == vaCategory
                && s.RUCategoryId == ruCategory)
            .FirstOrDefaultAsync(cancellationToken);

        assessment.SumVA = sumVa;
        assessment.SumRU = sumRu;
        assessment.Signature = signature?.Signature;
        assessment.CompletionDate = DateTime.UtcNow;
        assessment.TestStatus = 1;

        await foaRepository.UpdateAsync(assessment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new AssessmentResultDto(
            assessment.Id, "FOA", sumVa, sumRu,
            signature?.Signature, null);
    }

    // --- CFOA helpers ---

    private async Task<AssessmentDto> StartCfoaAssessmentAsync(StartAssessmentRequest request, CancellationToken cancellationToken)
    {
        var existing = await cfoaRepository.Query()
            .AsNoTracking()
            .Where(a => a.UserId == request.UserId && a.CompletionDate != null)
            .AnyAsync(cancellationToken);

        if (existing)
            throw new AssessmentAlreadyCompletedException($"User '{request.UserId}' has already completed CFOA assessment.");

        var assessment = new CfoaAssessment
        {
            UserId = request.UserId,
            StartDate = DateTime.UtcNow,
            CompanyName = request.CompanyName,
            TestStatus = 0,
            Cnt = 0
        };

        assessment = await cfoaRepository.AddAsync(assessment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new AssessmentDto(assessment.Id, assessment.UserId, "CFOA",
            assessment.StartDate, null, "0", null, null, null, assessment.CompanyName);
    }

    private async Task SubmitCfoaAnswerAsync(SubmitAnswerRequest request, CancellationToken cancellationToken)
    {
        var assessment = await cfoaRepository.Query()
            .Where(a => a.UserId == request.UserId && a.CompletionDate == null)
            .OrderByDescending(a => a.StartDate)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException("Active CFOA assessment not found for user.");

        var result = new CfoaResult
        {
            PID = assessment.PID,
            UserId = request.UserId,
            Question = request.QuestionNumber,
            Answer = request.Answer,
            Rating = request.Rating,
            EnterDate = DateTime.UtcNow
        };

        await cfoaResultRepository.AddAsync(result, cancellationToken);
        assessment.Cnt = (assessment.Cnt ?? 0) + 1;
        await cfoaRepository.UpdateAsync(assessment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private async Task<AssessmentResultDto> CompleteCfoaAssessmentAsync(CompleteAssessmentRequest request, CancellationToken cancellationToken)
    {
        var assessment = await cfoaRepository.Query()
            .Where(a => a.UserId == request.UserId && a.CompletionDate == null)
            .OrderByDescending(a => a.StartDate)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException("Active CFOA assessment not found for user.");

        var results = await cfoaResultRepository.Query()
            .AsNoTracking()
            .Where(r => r.UserId == request.UserId)
            .ToListAsync(cancellationToken);

        var sumVa = results.Where(r => r.Rating.HasValue).Sum(r => r.Rating!.Value);
        var sumRu = results.Count > 0 ? results.Count * 5 - sumVa : 0;

        var vaCategory = await GetCategoryIdAsync("CFOA", "VA", sumVa, cancellationToken);
        var ruCategory = await GetCategoryIdAsync("CFOA", "RU", sumRu, cancellationToken);

        var signature = await signatureRepository.Query()
            .AsNoTracking()
            .Where(s => s.AssessmentType == "CFOA"
                && s.VACategoryId == vaCategory
                && s.RUCategoryId == ruCategory)
            .FirstOrDefaultAsync(cancellationToken);

        assessment.SumVA = sumVa;
        assessment.SumRU = sumRu;
        assessment.Signature = signature?.Signature;
        assessment.CompletionDate = DateTime.UtcNow;
        assessment.TestStatus = 1;

        await cfoaRepository.UpdateAsync(assessment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new AssessmentResultDto(
            assessment.Id, "CFOA", sumVa, sumRu,
            signature?.Signature, null);
    }

    // --- EXOA helpers ---

    private async Task<AssessmentDto> StartExoaAssessmentAsync(StartAssessmentRequest request, CancellationToken cancellationToken)
    {
        var existing = await exoaRepository.Query()
            .AsNoTracking()
            .Where(a => a.UserId == request.UserId && a.CompletionDate != null)
            .AnyAsync(cancellationToken);

        if (existing)
            throw new AssessmentAlreadyCompletedException($"User '{request.UserId}' has already completed EXOA assessment.");

        var assessment = new ExoaAssessment
        {
            UserId = request.UserId,
            StartDate = DateTime.UtcNow,
            CompanyName = request.CompanyName,
            TestStatus = "0",
            Cnt = 0
        };

        assessment = await exoaRepository.AddAsync(assessment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new AssessmentDto(assessment.Id, assessment.UserId, "EXOA",
            assessment.StartDate, null, "0", null, null, null, assessment.CompanyName);
    }

    private async Task SubmitExoaAnswerAsync(SubmitAnswerRequest request, CancellationToken cancellationToken)
    {
        var assessment = await exoaRepository.Query()
            .Where(a => a.UserId == request.UserId && a.CompletionDate == null)
            .OrderByDescending(a => a.StartDate)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException("Active EXOA assessment not found for user.");

        var result = new ExoaResult
        {
            PID = assessment.PID,
            UserId = request.UserId,
            Question = request.QuestionNumber,
            Answer = request.Answer,
            Rating = request.Rating,
            EnterDate = DateTime.UtcNow
        };

        await exoaResultRepository.AddAsync(result, cancellationToken);
        assessment.Cnt = (assessment.Cnt ?? 0) + 1;
        await exoaRepository.UpdateAsync(assessment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private async Task<AssessmentResultDto> CompleteExoaAssessmentAsync(CompleteAssessmentRequest request, CancellationToken cancellationToken)
    {
        var assessment = await exoaRepository.Query()
            .Where(a => a.UserId == request.UserId && a.CompletionDate == null)
            .OrderByDescending(a => a.StartDate)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException("Active EXOA assessment not found for user.");

        assessment.CompletionDate = DateTime.UtcNow;
        assessment.TestStatus = "1";

        await exoaRepository.UpdateAsync(assessment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new AssessmentResultDto(
            assessment.Id, "EXOA", null, null,
            null, assessment.FinMission);
    }

    // --- ELA helpers ---

    private async Task<AssessmentDto> StartElaAssessmentAsync(StartAssessmentRequest request, CancellationToken cancellationToken)
    {
        var existing = await elaRepository.Query()
            .AsNoTracking()
            .Where(a => a.UserId == request.UserId && a.CompletionDate != null)
            .AnyAsync(cancellationToken);

        if (existing)
            throw new AssessmentAlreadyCompletedException($"User '{request.UserId}' has already completed ELA assessment.");

        var assessment = new ElaAssessment
        {
            UserId = request.UserId,
            StartDate = DateTime.UtcNow,
            TestStatus = "0",
            Cnt = 0
        };

        assessment = await elaRepository.AddAsync(assessment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new AssessmentDto(assessment.Id, assessment.UserId, "ELA",
            assessment.StartDate, null, "0", null, null, null, null);
    }

    private async Task SubmitElaAnswerAsync(SubmitAnswerRequest request, CancellationToken cancellationToken)
    {
        var assessment = await elaRepository.Query()
            .Where(a => a.UserId == request.UserId && a.CompletionDate == null)
            .OrderByDescending(a => a.StartDate)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException("Active ELA assessment not found for user.");

        var result = new ElaResult
        {
            PID = assessment.PID,
            UserId = request.UserId,
            Question = request.QuestionNumber,
            Answer = request.Answer,
            Rating = request.Rating,
            EnterDate = DateTime.UtcNow
        };

        await elaResultRepository.AddAsync(result, cancellationToken);
        assessment.Cnt = (assessment.Cnt ?? 0) + 1;
        await elaRepository.UpdateAsync(assessment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private async Task<AssessmentResultDto> CompleteElaAssessmentAsync(CompleteAssessmentRequest request, CancellationToken cancellationToken)
    {
        var assessment = await elaRepository.Query()
            .Where(a => a.UserId == request.UserId && a.CompletionDate == null)
            .OrderByDescending(a => a.StartDate)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new EntityNotFoundException("Active ELA assessment not found for user.");

        assessment.CompletionDate = DateTime.UtcNow;
        assessment.TestStatus = "1";

        await elaRepository.UpdateAsync(assessment, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new AssessmentResultDto(assessment.Id, "ELA", null, null, null, null);
    }

    // --- Status helpers ---

    private async Task<AssessmentStatusDto> GetFoaStatusAsync(string userId, CancellationToken cancellationToken)
    {
        var assessment = await foaRepository.Query()
            .AsNoTracking()
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.StartDate)
            .FirstOrDefaultAsync(cancellationToken);

        return new AssessmentStatusDto(
            userId, "FOA",
            assessment is not null,
            assessment?.CompletionDate is not null,
            assessment?.StartDate,
            assessment?.CompletionDate);
    }

    private async Task<AssessmentStatusDto> GetCfoaStatusAsync(string userId, CancellationToken cancellationToken)
    {
        var assessment = await cfoaRepository.Query()
            .AsNoTracking()
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.StartDate)
            .FirstOrDefaultAsync(cancellationToken);

        return new AssessmentStatusDto(
            userId, "CFOA",
            assessment is not null,
            assessment?.CompletionDate is not null,
            assessment?.StartDate,
            assessment?.CompletionDate);
    }

    private async Task<AssessmentStatusDto> GetExoaStatusAsync(string userId, CancellationToken cancellationToken)
    {
        var assessment = await exoaRepository.Query()
            .AsNoTracking()
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.StartDate)
            .FirstOrDefaultAsync(cancellationToken);

        return new AssessmentStatusDto(
            userId, "EXOA",
            assessment is not null,
            assessment?.CompletionDate is not null,
            assessment?.StartDate,
            assessment?.CompletionDate);
    }

    private async Task<AssessmentStatusDto> GetElaStatusAsync(string userId, CancellationToken cancellationToken)
    {
        var assessment = await elaRepository.Query()
            .AsNoTracking()
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.StartDate)
            .FirstOrDefaultAsync(cancellationToken);

        return new AssessmentStatusDto(
            userId, "ELA",
            assessment is not null,
            assessment?.CompletionDate is not null,
            assessment?.StartDate,
            assessment?.CompletionDate);
    }

    // --- Shared helpers ---

    private async Task<byte?> GetCategoryIdAsync(string assessmentType, string scoreType, int score, CancellationToken cancellationToken)
    {
        var category = await percentRepository.Query()
            .AsNoTracking()
            .Where(p => p.AssessmentType == assessmentType
                && p.ScoreType == scoreType
                && p.LowerBound <= score
                && p.UpperBound >= score)
            .FirstOrDefaultAsync(cancellationToken);

        return category?.CategoryId.HasValue == true ? (byte)category.CategoryId.Value : null;
    }
}
