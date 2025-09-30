using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.CreateProduct;
using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.DeleteProduct;
using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.UpdateProduct;
using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Queries.GetAllProducts;
using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Queries.GetProductById;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;

namespace E_Commerce.Application.Services.CommerceAttributeServices;

public interface IProductService
{
    Task CreateAsync(CreateProductCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(DeleteProductCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateProductCommand request, CancellationToken cancellationToken);
    Task<PagedList<Product>> GetAllAsync(GetAllProductsQuery request , CancellationToken cancellationToken);
    Task<Product> GetByIdAsync(GetProductByIdQuery request, CancellationToken cancellationToken);
}
