using FluentValidation;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.CreateProduct;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
         .NotEmpty().WithMessage("Product name is required.")
         .Length(2, 200).WithMessage("Product name must be between 2 and 200 characters.");
        RuleFor(x => x.ImageUrl)
         .NotEmpty().WithMessage("Image URL is required.")
         .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("Image URL must be a valid URL.");
        RuleFor(x => x.Description)
         .NotEmpty().WithMessage("Description is required.")
         .Length(10, 1000).WithMessage("Description must be between 10 and 1000 characters.");
        RuleFor(x => x.StockQuantity)
         .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative.");
        RuleFor(x => x.Price)
         .GreaterThan(0).WithMessage("Price must be greater than zero.");
        RuleFor(x => x.CategoryId)
         .GreaterThan(0).WithMessage("Category ID must be a positive integer.");
    }
}
