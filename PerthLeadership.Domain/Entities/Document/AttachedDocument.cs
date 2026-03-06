namespace PerthLeadership.Domain.Entities.Document;

public class AttachedDocument
{
    public int Id { get; set; }
    public string? ReferenceId { get; set; }
    public string? ReferenceType { get; set; }
    public DateTime? SavedDate { get; set; }
    public string? Title { get; set; }
    public string? DocumentName { get; set; }
    public byte[]? Content { get; set; }
    public string? ContentType { get; set; }
    public string? Description { get; set; }
}
