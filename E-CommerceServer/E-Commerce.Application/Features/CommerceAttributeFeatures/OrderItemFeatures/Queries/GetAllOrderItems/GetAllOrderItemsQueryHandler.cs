using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Queries.GetAllOrderItems;

public sealed class GetAllOrderItemsQueryHandler : IRequestHandler<GetAllOrderItemsQuery, PagedList<OrderItem>>
{
    private readonly IOrderItemService _orderItemService;

    public GetAllOrderItemsQueryHandler(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    public async Task<PagedList<OrderItem>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
    {
        return await _orderItemService.GetAllAsync(request, cancellationToken);
    }
}
