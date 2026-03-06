namespace PerthLeadership.Domain.Exceptions;

public sealed class BusinessRuleViolationException : DomainException
{
    public BusinessRuleViolationException() { }

    public BusinessRuleViolationException(string message)
        : base(message) { }

    public BusinessRuleViolationException(string message, Exception innerException)
        : base(message, innerException) { }
}
