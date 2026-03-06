namespace PerthLeadership.Domain.Entities.Client;

public class ClientContact
{
    public int ContactId { get; set; }
    public int ClientId { get; set; }
    public string? Salutation { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public int? State { get; set; }
    public string? Zip { get; set; }
    public string? Country { get; set; }
    public string? Phone1 { get; set; }
    public string? Phone2 { get; set; }
    public int? OverAllUserId { get; set; }
    public DateTime? CreatedOn { get; set; }

    // Navigation properties
    public ClientOrganization? ClientOrganization { get; set; }
}
