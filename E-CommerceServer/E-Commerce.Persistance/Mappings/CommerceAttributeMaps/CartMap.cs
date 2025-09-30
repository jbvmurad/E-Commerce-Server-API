using AutoMapper;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Command.CreateCart;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;

namespace E_Commerce.Persistance.Mappings.CommerceAttributeMaps;

public sealed class CartMap :Profile
{
    public CartMap() 
    {
        CreateMap<CreateCartCommand,Cart>().ReverseMap();
    }
}
