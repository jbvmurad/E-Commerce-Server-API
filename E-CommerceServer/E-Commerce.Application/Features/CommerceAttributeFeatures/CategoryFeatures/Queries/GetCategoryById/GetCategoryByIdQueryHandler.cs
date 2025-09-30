using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Queries.GetCategoryById;

public sealed class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
{
    private readonly ICategoryService _categoryService;

    public GetCategoryByIdQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        return await _categoryService.GetByIdAsync(request, cancellationToken);
    }
}