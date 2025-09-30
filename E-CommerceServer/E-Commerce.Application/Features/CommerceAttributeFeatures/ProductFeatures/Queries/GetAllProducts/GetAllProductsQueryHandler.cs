using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Queries.GetAllProducts;

public sealed class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PagedList<Product>>
{
    private readonly IProductService _productService;

    public GetAllProductsQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<PagedList<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productService.GetAllAsync(request, cancellationToken);
    }
}
