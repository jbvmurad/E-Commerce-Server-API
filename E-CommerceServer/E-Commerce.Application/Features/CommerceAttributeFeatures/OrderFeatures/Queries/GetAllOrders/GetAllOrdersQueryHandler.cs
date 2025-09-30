using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Queries.GetAllOrders;

public sealed class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, PagedList<Order>>
{
    private readonly IOrderService _orderService;

    public GetAllOrdersQueryHandler(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<PagedList<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        return await _orderService.GetAllAsync(request, cancellationToken);
        
    }
}
