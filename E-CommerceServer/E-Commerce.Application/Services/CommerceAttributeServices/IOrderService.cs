using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Commands.Order;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Commands.UpdateOrder;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Queries.GetAllOrders;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Queries.GetOrderById;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;

namespace E_Commerce.Application.Services.CommerceAttributeServices;

public interface IOrderService
{
    Task OrderAsync(OrderCommand request, CancellationToken cancellationToken);
    Task UpdateOrderAsync(UpdateOrderCommand request, CancellationToken cancellationToken);
    Task<PagedList<Order>> GetAllAsync(GetAllOrdersQuery request, CancellationToken cancellationToken);
    Task<Order> GetByIdAsync(GetOrderByIdQuery request, CancellationToken cancellationToken);
}
