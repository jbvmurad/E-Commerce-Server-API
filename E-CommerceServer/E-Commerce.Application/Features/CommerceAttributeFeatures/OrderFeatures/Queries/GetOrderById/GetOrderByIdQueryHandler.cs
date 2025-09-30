using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Queries.GetOrderById;

public sealed class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
{
    private readonly IOrderService _orderService;

    public GetOrderByIdQueryHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        return await _orderService.GetByIdAsync(request, cancellationToken);
    }
}
