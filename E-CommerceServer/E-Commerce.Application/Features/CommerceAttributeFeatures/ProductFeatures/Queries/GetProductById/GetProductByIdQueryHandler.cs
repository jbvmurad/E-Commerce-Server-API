using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Queries.GetProductById;

public sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly IProductService _productService;
    public GetProductByIdQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productService.GetByIdAsync(request, cancellationToken);
    }
}
