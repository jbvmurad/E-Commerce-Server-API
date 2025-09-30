using AutoMapper;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Command.CreateOrderItem;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;

namespace E_Commerce.Persistance.Mappings.CommerceAttributeMaps;

public sealed class OrderItemMap :Profile
{
    public OrderItemMap() 
    {
        CreateMap<OrderItem,CreateOrderItemCommand>().ReverseMap();
    }
}
