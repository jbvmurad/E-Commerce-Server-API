using FluentValidation;

namespace E_Commerce.Application.Features.UserAttributeFeatures.UserRoleFeatures.Commands.DeleteUserRole;

public sealed class DeleteUserRoleFullCommandValidator :AbstractValidator<DeleteUserRoleFullCommand>
{
    public DeleteUserRoleFullCommandValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("UserId must be greater than zero.");

        RuleFor(x => x.RoleIds)
            .NotEmpty()
            .WithMessage("At least one RoleId must be provided.");

        RuleForEach(x => x.RoleIds)
            .GreaterThan(0)
            .WithMessage("Each RoleId must be greater than zero.");
    }
}
