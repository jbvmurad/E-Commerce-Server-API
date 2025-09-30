using FluentValidation;

namespace E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.DeleteUser;

public sealed class DeleteUserCommandValidator :AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.Id)
           .GreaterThan(0).WithMessage("Invalid product ID.");
    }
}
