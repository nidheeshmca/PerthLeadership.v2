using FluentValidation;
using PerthLeadership.Application.DTOs.Client;

namespace PerthLeadership.Application.Validators;

public sealed class CreateClientRequestValidator : AbstractValidator<CreateClientRequest>
{
    public CreateClientRequestValidator()
    {
        RuleFor(x => x.CompanyName)
            .NotEmpty().WithMessage("Company name is required.")
            .MaximumLength(200).WithMessage("Company name must not exceed 200 characters.");

        RuleFor(x => x.BillingAddress1)
            .NotEmpty().WithMessage("Billing address is required.")
            .MaximumLength(500).WithMessage("Billing address must not exceed 500 characters.");

        RuleFor(x => x.BillingCountry)
            .NotEmpty().WithMessage("Billing country is required.");

        RuleFor(x => x.ShippingAddress1)
            .NotEmpty().WithMessage("Shipping address is required.")
            .MaximumLength(500).WithMessage("Shipping address must not exceed 500 characters.");

        RuleFor(x => x.ShippingCountry)
            .NotEmpty().WithMessage("Shipping country is required.");

        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status is required.");
    }
}
