using FluentValidation;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.UpdateCategory;

public sealed class UpdateCategoryCommandValidator: AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
         .GreaterThan(0).WithMessage("Invalid category ID.");
        RuleFor(x => x.Name)
         .NotEmpty().WithMessage("Category name is required.")
         .Length(2, 100).WithMessage("Category name must be between 2 and 100 characters.");
    }
}
