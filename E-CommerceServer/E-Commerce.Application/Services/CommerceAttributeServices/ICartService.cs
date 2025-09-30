using E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Command.CreateCart;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Queries.GetAllCarts;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Queries.GetCartById;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;

namespace E_Commerce.Application.Services.CommerceAttributeServices;

public interface ICartService
{
    Task<PagedList<Cart>> GetAllAsync(GetAllCartsQuery request,CancellationToken cancellationToken);
    Task<Cart> GetByIdAsync(GetCartByIdQuery request,CancellationToken cancellationToken);
    Task CreateAsync(CreateCartCommand request,CancellationToken cancellationToken);
}
