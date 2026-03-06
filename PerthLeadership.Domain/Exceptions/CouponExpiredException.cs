namespace PerthLeadership.Domain.Exceptions;

public sealed class CouponExpiredException : DomainException
{
    public CouponExpiredException() { }

    public CouponExpiredException(string message)
        : base(message) { }

    public CouponExpiredException(string message, Exception innerException)
        : base(message, innerException) { }
}
