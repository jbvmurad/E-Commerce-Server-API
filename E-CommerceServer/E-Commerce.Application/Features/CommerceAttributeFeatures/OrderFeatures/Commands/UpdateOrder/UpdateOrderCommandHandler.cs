using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Commands.UpdateOrder;

public sealed class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, MessageResponse>
{
    private readonly IOrderService _orderService;
    public UpdateOrderCommandHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }
    public async Task<MessageResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        await _orderService.UpdateOrderAsync(request, cancellationToken);
        return new MessageResponse("Order updated successfully.");
    }
}
