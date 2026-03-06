namespace PerthLeadership.Domain.Entities.Assessment;

public class CfoaQuestionV2
{
    public int Id { get; set; }
    public string? Question { get; set; }
    public string? QA { get; set; }
    public string? QB { get; set; }
    public string? QC { get; set; }
    public string? QD { get; set; }
    public string? QE { get; set; }
    public string? QF { get; set; }
    public string? Type { get; set; }
    public bool? IsGenuine { get; set; }
    public string? Category { get; set; }
    public short? A { get; set; }
    public short? B { get; set; }
    public short? C { get; set; }
    public short? D { get; set; }
    public short? E { get; set; }
    public short? F { get; set; }
    public int? QuestionIdRef { get; set; }
    public DateTime? LastModified { get; set; }
}
