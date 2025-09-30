using AutoMapper;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.CreateCategory;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.UpdateCategory;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;

namespace E_Commerce.Persistance.Mappings.CommerceAttributeMaps;

public sealed class CategoryMap :Profile
{
    public CategoryMap()
    {
        CreateMap<CreateCategoryCommand,Category>().ReverseMap();
        CreateMap<UpdateCategoryCommand,Category>().ReverseMap();
    }
}
