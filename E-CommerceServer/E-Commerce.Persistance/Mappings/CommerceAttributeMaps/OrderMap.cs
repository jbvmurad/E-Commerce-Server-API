using AutoMapper;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Commands.Order;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Commands.UpdateOrder;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;

namespace E_Commerce.Persistance.Mappings.CommerceAttributeMaps;

public sealed class OrderMap :Profile
{
    public OrderMap()
    {
        CreateMap<OrderCommand, Order>().ReverseMap();
        CreateMap<UpdateOrderCommand, Order>().ReverseMap();
    }
}
