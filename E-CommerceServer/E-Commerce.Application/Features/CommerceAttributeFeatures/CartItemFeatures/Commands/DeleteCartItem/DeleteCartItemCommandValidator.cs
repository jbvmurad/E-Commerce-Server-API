using FluentValidation;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.DeleteCartItem;

public sealed class DeleteCartItemCommandValidator :AbstractValidator<DeleteCartItemCommand>
{
    public DeleteCartItemCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}
