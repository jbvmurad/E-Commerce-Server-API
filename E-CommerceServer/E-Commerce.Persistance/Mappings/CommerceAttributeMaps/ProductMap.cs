using AutoMapper;
using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.CreateProduct;
using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.UpdateProduct;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;

namespace E_Commerce.Persistance.Mappings.CommerceAttributeMaps;

public sealed class ProductMap:Profile
{
    public ProductMap()
    {
        CreateMap<CreateProductCommand, Product>().ReverseMap();
        CreateMap<UpdateProductCommand, Product>().ReverseMap();
    }
}
