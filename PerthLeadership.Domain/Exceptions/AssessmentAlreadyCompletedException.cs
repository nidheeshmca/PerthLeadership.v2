namespace PerthLeadership.Domain.Exceptions;

public sealed class AssessmentAlreadyCompletedException : DomainException
{
    public AssessmentAlreadyCompletedException() { }

    public AssessmentAlreadyCompletedException(string message)
        : base(message) { }

    public AssessmentAlreadyCompletedException(string message, Exception innerException)
        : base(message, innerException) { }
}
