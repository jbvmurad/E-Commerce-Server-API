using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Queries.GetOrderItemById;

public sealed class GetOrderItemByIdQueryHandler : IRequestHandler<GetOrderItemByIdQuery, OrderItem>
{
    private readonly IOrderItemService _orderItemService;

    public GetOrderItemByIdQueryHandler(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    public async Task<OrderItem> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
    {
        return await _orderItemService.GetByIdAsync(request, cancellationToken);
    }
}
