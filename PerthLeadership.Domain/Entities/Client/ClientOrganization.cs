namespace PerthLeadership.Domain.Entities.Client;

public class ClientOrganization
{
    public int ClientId { get; set; }
    public string? ClientCode { get; set; }
    public string CompanyName { get; set; } = null!;
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public int? State { get; set; }
    public string? Zip { get; set; }
    public string? Country { get; set; }
    public string? Website { get; set; }
    public string? PhoneNo1 { get; set; }
    public string? PhoneNo2 { get; set; }
    public string Status { get; set; } = null!;
    public string? Comments { get; set; }
    public string BillingAddress1 { get; set; } = null!;
    public string? BillingAddress2 { get; set; }
    public string? BillingCity { get; set; }
    public string? BillingState { get; set; }
    public string? BillingZip { get; set; }
    public string BillingCountry { get; set; } = null!;
    public string? BillingPhoneNo1 { get; set; }
    public string? BillingPhoneNo2 { get; set; }
    public bool? IsSameBilling { get; set; }
    public string ShippingAddress1 { get; set; } = null!;
    public string? ShippingAddress2 { get; set; }
    public string? ShippingCity { get; set; }
    public string? ShippingState { get; set; }
    public string? ShippingZip { get; set; }
    public string ShippingCountry { get; set; } = null!;
    public string? ShippingPhone1 { get; set; }
    public string? ShippingPhone2 { get; set; }
    public int OverAllUserId { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool? Archieve { get; set; }

    // Navigation properties
    public OverAllUser? OverAllUser { get; set; }
    public ICollection<Subject> Subjects { get; set; } = [];
    public ICollection<ClientContact> ClientContacts { get; set; } = [];
    public ICollection<AssignProgram> AssignPrograms { get; set; } = [];
    public ICollection<Coupon> Coupons { get; set; } = [];
}
