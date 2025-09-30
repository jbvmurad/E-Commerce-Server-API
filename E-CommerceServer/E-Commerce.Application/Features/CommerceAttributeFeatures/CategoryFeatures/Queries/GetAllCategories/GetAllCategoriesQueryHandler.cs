using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Queries.GetAllCategories;

public sealed class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, PagedList<Category>>
{
    private readonly ICategoryService _categoryService;

    public GetAllCategoriesQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<PagedList<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _categoryService.GetAllAsync(request, cancellationToken);
    }
}
