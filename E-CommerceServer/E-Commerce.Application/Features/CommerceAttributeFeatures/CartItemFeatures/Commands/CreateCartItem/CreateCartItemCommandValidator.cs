using FluentValidation;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.CreateCartItem;

public sealed class CreateCartItemCommandValidator:AbstractValidator<CreateCartItemCommand>
{
    public CreateCartItemCommandValidator()
    {
        RuleFor(x => x.CartId)
            .GreaterThan(0).WithMessage("CartId must be greater than 0.");
        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        RuleFor(x => x.UnitPrice)
            .GreaterThan(0).WithMessage("UnitPrice must be greater than 0.");
    }
}
