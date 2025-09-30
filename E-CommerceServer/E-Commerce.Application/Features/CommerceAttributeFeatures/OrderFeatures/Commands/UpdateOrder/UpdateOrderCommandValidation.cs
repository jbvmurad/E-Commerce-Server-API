using FluentValidation;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Commands.UpdateOrder;

public sealed class UpdateOrderCommandValidation:AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidation()
    {
        RuleFor(x => x.Id)
         .GreaterThan(0).WithMessage("Invalid category ID.");
        RuleFor(x => x.Status)
         .IsInEnum().WithMessage("Invalid order status.");
    }
}
