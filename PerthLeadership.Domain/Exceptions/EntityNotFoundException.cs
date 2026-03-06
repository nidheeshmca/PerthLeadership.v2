namespace PerthLeadership.Domain.Exceptions;

public sealed class EntityNotFoundException : DomainException
{
    public EntityNotFoundException() { }

    public EntityNotFoundException(string entityName, object key)
        : base($"Entity '{entityName}' with key '{key}' was not found.") { }

    public EntityNotFoundException(string message)
        : base(message) { }

    public EntityNotFoundException(string message, Exception innerException)
        : base(message, innerException) { }
}
