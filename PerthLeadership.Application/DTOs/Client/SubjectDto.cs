namespace PerthLeadership.Application.DTOs.Client;
public sealed record SubjectDto(
    int SubjectId, string? Salutation, string? FirstName, string? LastName,
    string? Email, string? Organization, string? Designation,
    int? ClientId, string? City, string? Country, DateTime? CreatedOn,
    string? FinancialMission, string? UserType);

public sealed record CreateSubjectRequest(
    string? Salutation, string FirstName, string LastName,
    string Email, string? Password, string? Organization, string? Designation,
    string? Address1, string? Address2, string? City, int? State,
    string? Zip, string? Country, string? Phone1, string? Phone2,
    int? ClientId, string? UserType, int? LanguageId);

public sealed record UpdateSubjectRequest(
    string? Salutation, string? FirstName, string? LastName,
    string? Email, string? Organization, string? Designation,
    string? Address1, string? Address2, string? City, int? State,
    string? Zip, string? Country, string? Phone1, string? Phone2,
    string? FinancialMission, string? UserType, int? LanguageId);
