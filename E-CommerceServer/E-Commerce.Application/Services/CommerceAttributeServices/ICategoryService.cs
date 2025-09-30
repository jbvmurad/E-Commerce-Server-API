using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.CreateCategory;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.DeleteCategory;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.UpdateCategory;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Queries.GetAllCategories;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Queries.GetCategoryById;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;

namespace E_Commerce.Application.Services.CommerceAttributeServices;

public interface ICategoryService
{
    Task CreateAsync(CreateCategoryCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateCategoryCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(DeleteCategoryCommand request, CancellationToken cancellationToken);
    Task<PagedList<Category>> GetAllAsync(GetAllCategoriesQuery request, CancellationToken cancellationToken);
    Task<Category> GetByIdAsync(GetCategoryByIdQuery request, CancellationToken cancellationToken);

}
