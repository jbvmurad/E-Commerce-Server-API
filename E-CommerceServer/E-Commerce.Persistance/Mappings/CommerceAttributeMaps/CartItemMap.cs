using AutoMapper;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.CreateCartItem;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.UpdateCartItem;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;

namespace E_Commerce.Persistance.Mappings.CommerceAttributeMaps;

public sealed class CartItemMap:Profile
{
    public CartItemMap()
    {
        CreateMap<CreateCartItemCommand,CartItem>().ReverseMap();
        CreateMap<UpdateCartItemCommand,CartItem>().ReverseMap();
    }
}
