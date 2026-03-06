namespace PerthLeadership.Application.Interfaces;
using PerthLeadership.Application.DTOs.Assessment;

public interface IAssessmentService
{
    Task<AssessmentDto?> GetFoaAssessmentAsync(string userId, CancellationToken cancellationToken = default);
    Task<AssessmentDto?> GetCfoaAssessmentAsync(string userId, CancellationToken cancellationToken = default);
    Task<AssessmentDto?> GetExoaAssessmentAsync(string userId, CancellationToken cancellationToken = default);
    Task<AssessmentDto?> GetElaAssessmentAsync(string userId, CancellationToken cancellationToken = default);
    Task<AssessmentDto> StartAssessmentAsync(StartAssessmentRequest request, CancellationToken cancellationToken = default);
    Task SubmitAnswerAsync(SubmitAnswerRequest request, CancellationToken cancellationToken = default);
    Task<AssessmentResultDto> CompleteAssessmentAsync(CompleteAssessmentRequest request, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<QuestionDto>> GetQuestionsAsync(string assessmentType, int? version, CancellationToken cancellationToken = default);
    Task<AssessmentStatusDto> GetUserStatusAsync(string userId, string assessmentType, CancellationToken cancellationToken = default);
}
