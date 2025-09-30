using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Queries.GetAllCartItems;

public sealed class GetAllCartItemsQueryHandler : IRequestHandler<GetAllCartItemsQuery, PagedList<CartItem>>
{
    private readonly ICartItemService _cartItemService;

    public GetAllCartItemsQueryHandler(ICartItemService cartItemService)
    {
        _cartItemService = cartItemService;
    }

    public async Task<PagedList<CartItem>> Handle(GetAllCartItemsQuery request, CancellationToken cancellationToken)
    {
        return await _cartItemService.GetAllAsync(request, cancellationToken);
    }
}
