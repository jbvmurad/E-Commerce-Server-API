using FluentValidation;

namespace E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.Login;

public sealed class LoginCommandValidator :AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.UserNameOrEmail)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Email or UserName is required.")
            .NotNull().WithMessage("Email or UserName is required.");
    }
}
