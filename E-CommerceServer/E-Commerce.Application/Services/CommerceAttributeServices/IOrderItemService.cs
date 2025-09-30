using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Command.CreateOrderItem;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Queries.GetAllOrderItems;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Queries.GetOrderItemById;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;

namespace E_Commerce.Application.Services.CommerceAttributeServices;

public interface IOrderItemService
{
    Task<PagedList<OrderItem>> GetAllAsync(GetAllOrderItemsQuery request,CancellationToken cancellationToken);
    Task<OrderItem> GetByIdAsync(GetOrderItemByIdQuery request,CancellationToken cancellationToken);
    Task CreateAsync(CreateOrderItemCommand request,CancellationToken cancellationToken);
}
