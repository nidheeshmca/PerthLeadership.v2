using Microsoft.AspNetCore.Mvc;
using PerthLeadership.Application.DTOs.Client;
using PerthLeadership.Application.Interfaces;

namespace PerthLeadership.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CouponsController(ICouponService couponService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CouponDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var coupon = await couponService.GetByIdAsync(id, cancellationToken);
        return coupon is null ? NotFound() : Ok(coupon);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<CouponDto>>> GetAll(CancellationToken cancellationToken)
    {
        var coupons = await couponService.GetAllAsync(cancellationToken);
        return Ok(coupons);
    }

    [HttpPost]
    public async Task<ActionResult<CouponDto>> Create([FromBody] CreateCouponRequest request, CancellationToken cancellationToken)
    {
        var coupon = await couponService.CreateAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = coupon.CouponId }, coupon);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<CouponDto>> Update(int id, [FromBody] UpdateCouponRequest request, CancellationToken cancellationToken)
    {
        var coupon = await couponService.UpdateAsync(id, request, cancellationToken);
        return Ok(coupon);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await couponService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }

    [HttpPost("assign")]
    public async Task<ActionResult<CouponDto>> Assign([FromBody] AssignCouponRequest request, CancellationToken cancellationToken)
    {
        var coupon = await couponService.AssignCouponAsync(request, cancellationToken);
        return Ok(coupon);
    }

    [HttpGet("validate")]
    public async Task<ActionResult<bool>> Validate([FromQuery] string couponNo, [FromQuery] string email, CancellationToken cancellationToken)
    {
        var isValid = await couponService.ValidateCouponAsync(couponNo, email, cancellationToken);
        return Ok(isValid);
    }
}
