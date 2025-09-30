using FluentValidation;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Command.CreateCart;

public sealed class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    public CreateCartCommandValidator()
    {
        RuleFor(x => x.UserId)
          .GreaterThan(0).WithMessage("UserId must be greater than 0.");
    }
}
