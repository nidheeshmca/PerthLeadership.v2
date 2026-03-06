namespace PerthLeadership.Application.Interfaces;
using PerthLeadership.Application.DTOs.Client;

public interface ICouponService
{
    Task<CouponDto?> GetByIdAsync(int couponId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<CouponDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CouponDto> CreateAsync(CreateCouponRequest request, CancellationToken cancellationToken = default);
    Task<CouponDto> UpdateAsync(int couponId, UpdateCouponRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int couponId, CancellationToken cancellationToken = default);
    Task<CouponDto> AssignCouponAsync(AssignCouponRequest request, CancellationToken cancellationToken = default);
    Task<bool> ValidateCouponAsync(string couponNo, string email, CancellationToken cancellationToken = default);
}
