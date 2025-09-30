using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.CreateCartItem;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.DeleteCartItem;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.UpdateCartItem;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Queries.GetAllCartItems;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Queries.GetCartItemById;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;

namespace E_Commerce.Application.Services.CommerceAttributeServices;

public interface ICartItemService
{
    Task CreateAsync(CreateCartItemCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateCartItemCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(DeleteCartItemCommand request, CancellationToken cancellationToken);
    Task<PagedList<CartItem>> GetAllAsync(GetAllCartItemsQuery request,CancellationToken cancellationToken);
    Task<CartItem> GetByIdAsync(GetCartItemByIdQuery request,CancellationToken cancellationToken);
}
