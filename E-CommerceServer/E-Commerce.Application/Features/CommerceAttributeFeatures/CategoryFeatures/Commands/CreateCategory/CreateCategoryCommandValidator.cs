using FluentValidation;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.CreateCategory;

public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
         .NotEmpty().WithMessage("Category name is required.")
         .Length(2, 100).WithMessage("Category name must be between 2 and 100 characters.");
    }
}
