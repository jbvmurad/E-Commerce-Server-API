using FluentValidation;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.UpdateProduct;

public sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Invalid category ID.");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .Length(2, 150).WithMessage("Product name must be between 2 and 150 characters.");
        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Image URL is required.")
            .MaximumLength(300).WithMessage("Image URL must not exceed 300 characters.")
            .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            .WithMessage("Image URL must be a valid URL.");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .Length(10, 1000).WithMessage("Description must be between 10 and 1000 characters.");
        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Stock quantity must be zero or a positive number.");
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be a positive number.");
        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid status selected. Valid status are: Active, InActive, OutOfStock.");
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Category is required.")
            .GreaterThan(0).WithMessage("Category ID must be greater than 0.");
    }
}
