namespace PerthLeadership.Application.DTOs.Client;
public sealed record ClientDto(
    int ClientId, string? ClientCode, string CompanyName,
    string? City, string? Country, string Status, DateTime CreatedOn, bool? IsArchived);

public sealed record ClientDetailDto(
    int ClientId, string? ClientCode, string CompanyName,
    string? Address1, string? Address2, string? City, int? State,
    string? Zip, string? Country, string? Website, string? PhoneNo1,
    string Status, string? Comments, DateTime CreatedOn,
    IReadOnlyList<ClientContactDto> Contacts,
    IReadOnlyList<ProgramDto> Programs);

public sealed record ClientContactDto(
    Guid Id, string? Salutation, string? FirstName, string? LastName,
    string? Email, string? Phone1, string? City, string? Country);

public sealed record CreateClientRequest(
    string? ClientCode, string CompanyName, string? Address1, string? Address2,
    string? City, int? State, string? Zip, string? Country, string? Website,
    string? PhoneNo1, string? PhoneNo2, string Status, string? Comments,
    string BillingAddress1, string? BillingAddress2, string? BillingCity,
    string? BillingState, string? BillingZip, string BillingCountry,
    bool? IsSameBilling, string ShippingAddress1, string? ShippingAddress2,
    string? ShippingCity, string? ShippingState, string? ShippingZip,
    string ShippingCountry);

public sealed record UpdateClientRequest(
    string? ClientCode, string? CompanyName, string? Address1, string? Address2,
    string? City, int? State, string? Zip, string? Country, string? Website,
    string? PhoneNo1, string? PhoneNo2, string? Status, string? Comments,
    bool? IsArchived);
