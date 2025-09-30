using FluentValidation;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.UpdateCartItem;

public sealed class UpdateCartItemCommandValidator: AbstractValidator<UpdateCartItemCommand>
{
    public UpdateCartItemCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
    }
}
