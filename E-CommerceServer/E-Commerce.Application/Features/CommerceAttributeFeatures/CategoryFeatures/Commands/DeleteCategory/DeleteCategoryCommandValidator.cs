using FluentValidation;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.DeleteCategory;

public sealed class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
         .GreaterThan(0).WithMessage("Invalid category ID.");
    }
}
