using FluentValidation;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Command.CreateOrderItem;

public sealed class CreateOrderItemCommandValidation :AbstractValidator<CreateOrderItemCommand>
{
    public CreateOrderItemCommandValidation()
    {
        RuleFor(x => x.ProductId)
          .GreaterThan(0).WithMessage("Product ID must be a positive integer.");
        RuleFor(x => x.OrderId)
          .GreaterThan(0).WithMessage("Order ID must be a positive integer.");
    }
}
