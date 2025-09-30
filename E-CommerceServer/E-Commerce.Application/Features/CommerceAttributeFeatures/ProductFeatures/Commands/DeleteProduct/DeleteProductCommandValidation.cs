using FluentValidation;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.DeleteProduct;

public sealed class DeleteProductCommandValidation: AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidation()
    {
        RuleFor(x => x.Id)
         .GreaterThan(0).WithMessage("Invalid product ID.");
    }
}
