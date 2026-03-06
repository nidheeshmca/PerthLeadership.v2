namespace PerthLeadership.Application.DTOs.Assessment;
public sealed record AssessmentDto(
    int Id, string? UserId, string AssessmentType,
    DateTime? StartDate, DateTime? CompletionDate,
    string? TestStatus, int? SumVa, int? SumRu,
    string? Signature, string? CompanyName);

public sealed record AssessmentStatusDto(
    string UserId, string AssessmentType, bool HasStarted,
    bool IsCompleted, DateTime? StartDate, DateTime? CompletionDate);

public sealed record AssessmentResultDto(
    int AssessmentId, string AssessmentType, int? SumVa, int? SumRu,
    string? Signature, string? FinancialMission);

public sealed record StartAssessmentRequest(
    string UserId, string AssessmentType, string? CompanyName);

public sealed record SubmitAnswerRequest(
    string UserId, string AssessmentType, int QuestionNumber,
    string Answer, int Rating);

public sealed record CompleteAssessmentRequest(
    string UserId, string AssessmentType);

public sealed record QuestionDto(
    int Id, string? Question, string? AnswerLeft, string? AnswerRight,
    string? Type, bool? IsGenuine, string? Category);

public sealed record SignatureDto(
    string? Signature, string? ValuationOutcome,
    string? MissionImage, string? GraphImage);
