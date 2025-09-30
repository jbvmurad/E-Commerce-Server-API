using FluentValidation;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Commands.Order;

public sealed class OrderCommandValidation : AbstractValidator<OrderCommand>
{
    public OrderCommandValidation()
    {
        RuleFor(x => x.ShippingAddress)
         .NotEmpty().WithMessage("Shipping address is required.")
         .Length(10, 300).WithMessage("Shipping address must be between 10 and 300 characters.");
        RuleFor(x=>x.UserId)
            .GreaterThan(0).WithMessage("User ID must be a positive integer.");
    }
}
