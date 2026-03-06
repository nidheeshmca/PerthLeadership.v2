using Microsoft.EntityFrameworkCore;
using PerthLeadership.Application.DTOs.Client;
using PerthLeadership.Application.Interfaces;
using PerthLeadership.Domain.Entities.Client;
using PerthLeadership.Domain.Exceptions;
using PerthLeadership.Domain.Interfaces;

namespace PerthLeadership.Application.Services;

public sealed class CouponService(
    IRepository<Coupon> couponRepository,
    IRepository<AssignCoupon> assignCouponRepository,
    IRepository<Subject> subjectRepository,
    IUnitOfWork unitOfWork) : ICouponService
{
    public async Task<CouponDto?> GetByIdAsync(int couponId, CancellationToken cancellationToken = default)
    {
        return await couponRepository.Query()
            .AsNoTracking()
            .Where(c => c.CouponId == couponId)
            .Select(c => new CouponDto(
                c.CouponId, c.CouponNo, c.CouponType, c.DaysToExpire,
                c.CreatedDate, c.ClientId, c.Series, c.AssessmentType,
                c.CouponLimit, c.DueDate, c.UserReport))
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<CouponDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await couponRepository.Query()
            .AsNoTracking()
            .OrderByDescending(c => c.CreatedDate)
            .Select(c => new CouponDto(
                c.CouponId, c.CouponNo, c.CouponType, c.DaysToExpire,
                c.CreatedDate, c.ClientId, c.Series, c.AssessmentType,
                c.CouponLimit, c.DueDate, c.UserReport))
            .ToListAsync(cancellationToken);
    }

    public async Task<CouponDto> CreateAsync(CreateCouponRequest request, CancellationToken cancellationToken = default)
    {
        var coupon = new Coupon
        {
            CouponNo = request.CouponNo ?? Guid.NewGuid().ToString("N")[..12].ToUpperInvariant(),
            CouponType = request.CouponType,
            DaysToExpire = request.DaysToExpire,
            ClientId = request.ClientId,
            LicenseeId = request.LicenseeId,
            CreatorId = request.CreatorId,
            Series = request.Series,
            Comments = request.Comments,
            CouponLimit = request.CouponLimit,
            ProjectId = request.ProjectId,
            AssessmentType = request.AssessmentType,
            UserReport = request.UserReport,
            DueDate = request.DueDate,
            CreatedDate = DateTime.UtcNow
        };

        coupon = await couponRepository.AddAsync(coupon, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CouponDto(
            coupon.CouponId, coupon.CouponNo, coupon.CouponType, coupon.DaysToExpire,
            coupon.CreatedDate, coupon.ClientId, coupon.Series, coupon.AssessmentType,
            coupon.CouponLimit, coupon.DueDate, coupon.UserReport);
    }

    public async Task<CouponDto> UpdateAsync(int couponId, UpdateCouponRequest request, CancellationToken cancellationToken = default)
    {
        var coupon = await couponRepository.GetByIdAsync(couponId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Coupon), couponId);

        if (request.CouponType is not null) coupon.CouponType = request.CouponType;
        if (request.DaysToExpire is not null) coupon.DaysToExpire = request.DaysToExpire;
        if (request.Series is not null) coupon.Series = request.Series;
        if (request.Comments is not null) coupon.Comments = request.Comments;
        if (request.CouponLimit is not null) coupon.CouponLimit = request.CouponLimit;
        if (request.AssessmentType is not null) coupon.AssessmentType = request.AssessmentType;
        if (request.UserReport is not null) coupon.UserReport = request.UserReport;
        if (request.DueDate is not null) coupon.DueDate = request.DueDate;

        await couponRepository.UpdateAsync(coupon, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CouponDto(
            coupon.CouponId, coupon.CouponNo, coupon.CouponType, coupon.DaysToExpire,
            coupon.CreatedDate, coupon.ClientId, coupon.Series, coupon.AssessmentType,
            coupon.CouponLimit, coupon.DueDate, coupon.UserReport);
    }

    public async Task DeleteAsync(int couponId, CancellationToken cancellationToken = default)
    {
        var coupon = await couponRepository.GetByIdAsync(couponId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Coupon), couponId);

        await couponRepository.DeleteAsync(coupon, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<CouponDto> AssignCouponAsync(AssignCouponRequest request, CancellationToken cancellationToken = default)
    {
        var coupon = await couponRepository.GetByIdAsync(request.CouponId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Coupon), request.CouponId);

        // Check if coupon has expired
        if (coupon.DueDate.HasValue && coupon.DueDate.Value < DateTime.UtcNow)
            throw new CouponExpiredException($"Coupon '{coupon.CouponNo}' has expired.");

        if (coupon.CreatedDate.HasValue && coupon.DaysToExpire.HasValue)
        {
            var expiryDate = coupon.CreatedDate.Value.AddDays(coupon.DaysToExpire.Value);
            if (expiryDate < DateTime.UtcNow)
                throw new CouponExpiredException($"Coupon '{coupon.CouponNo}' has expired.");
        }

        // Check coupon usage limit
        if (coupon.CouponLimit.HasValue)
        {
            var usageCount = await assignCouponRepository.Query()
                .AsNoTracking()
                .CountAsync(ac => ac.CouponId == coupon.CouponId, cancellationToken);

            if (usageCount >= coupon.CouponLimit.Value)
                throw new BusinessRuleViolationException($"Coupon '{coupon.CouponNo}' has reached its usage limit.");
        }

        var subject = await subjectRepository.GetByIdAsync(request.SubjectId, cancellationToken)
            ?? throw new EntityNotFoundException(nameof(Subject), request.SubjectId);

        var assignCoupon = new AssignCoupon
        {
            CouponId = request.CouponId,
            SubjectId = request.SubjectId,
            Email = request.Email ?? subject.Email,
            Name = request.Name,
            Msg = request.Message,
            SentOn = DateTime.UtcNow,
            Version = request.Version,
            AssignSubjectId = request.AssignSubjectId,
            AssessmentType = request.AssessmentType,
            Status = "Assigned"
        };

        await assignCouponRepository.AddAsync(assignCoupon, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CouponDto(
            coupon.CouponId, coupon.CouponNo, coupon.CouponType, coupon.DaysToExpire,
            coupon.CreatedDate, coupon.ClientId, coupon.Series, coupon.AssessmentType,
            coupon.CouponLimit, coupon.DueDate, coupon.UserReport);
    }

    public async Task<bool> ValidateCouponAsync(string couponNo, string email, CancellationToken cancellationToken = default)
    {
        var coupon = await couponRepository.Query()
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CouponNo == couponNo, cancellationToken);

        if (coupon is null)
            return false;

        // Check expiry by DueDate
        if (coupon.DueDate.HasValue && coupon.DueDate.Value < DateTime.UtcNow)
            return false;

        // Check expiry by DaysToExpire
        if (coupon.CreatedDate.HasValue && coupon.DaysToExpire.HasValue)
        {
            var expiryDate = coupon.CreatedDate.Value.AddDays(coupon.DaysToExpire.Value);
            if (expiryDate < DateTime.UtcNow)
                return false;
        }

        // Check coupon usage limit
        if (coupon.CouponLimit.HasValue)
        {
            var usageCount = await assignCouponRepository.Query()
                .AsNoTracking()
                .CountAsync(ac => ac.CouponId == coupon.CouponId, cancellationToken);

            if (usageCount >= coupon.CouponLimit.Value)
                return false;
        }

        // Verify the coupon is assigned to this email
        var isAssigned = await assignCouponRepository.Query()
            .AsNoTracking()
            .AnyAsync(ac => ac.CouponId == coupon.CouponId && ac.Email == email, cancellationToken);

        return isAssigned;
    }
}
