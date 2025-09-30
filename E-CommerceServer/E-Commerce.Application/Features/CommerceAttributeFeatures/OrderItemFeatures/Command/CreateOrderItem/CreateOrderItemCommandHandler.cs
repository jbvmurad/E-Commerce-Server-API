using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Command.CreateOrderItem;

public sealed class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, MessageResponse>
{
    private readonly IOrderItemService _orderItemService;

    public CreateOrderItemCommandHandler(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    public async Task<MessageResponse> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        await _orderItemService.CreateAsync(request, cancellationToken);
        return new MessageResponse("Order item created successfully.");
    }
}
