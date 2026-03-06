using FluentValidation;
using PerthLeadership.Application.DTOs.Client;

namespace PerthLeadership.Application.Validators;

public sealed class CreateCouponRequestValidator : AbstractValidator<CreateCouponRequest>
{
    private static readonly string[] ValidAssessmentTypes = ["FOA", "CFOA", "EXOA", "ELA"];

    public CreateCouponRequestValidator()
    {
        RuleFor(x => x.CouponType)
            .NotEmpty().WithMessage("Coupon type is required.");

        RuleFor(x => x.DaysToExpire)
            .GreaterThan(0).WithMessage("Days to expire must be greater than 0.");

        RuleFor(x => x.ClientId)
            .GreaterThan(0).WithMessage("Client ID must be a valid positive integer.");

        RuleFor(x => x.AssessmentType)
            .NotEmpty().WithMessage("Assessment type is required.")
            .Must(type => ValidAssessmentTypes.Contains(type, StringComparer.OrdinalIgnoreCase))
            .WithMessage("Assessment type must be one of: FOA, CFOA, EXOA, ELA.");
    }
}
