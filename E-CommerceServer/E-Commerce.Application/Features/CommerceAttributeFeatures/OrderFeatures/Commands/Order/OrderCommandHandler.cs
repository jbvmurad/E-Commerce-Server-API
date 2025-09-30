using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Commands.Order;

public sealed class OrderCommandHandler : IRequestHandler<OrderCommand, MessageResponse>
{
    private readonly IOrderService _orderService;
    public OrderCommandHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public async Task<MessageResponse> Handle(OrderCommand request, CancellationToken cancellationToken)
    {
        await _orderService.OrderAsync(request, cancellationToken);
        return new MessageResponse("Order created successfully.");
    }
}
