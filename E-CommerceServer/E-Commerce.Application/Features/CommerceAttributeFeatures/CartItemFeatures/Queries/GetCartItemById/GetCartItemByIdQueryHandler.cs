using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Queries.GetCartItemById;

public class GetCartItemByIdQueryHandler : IRequestHandler<GetCartItemByIdQuery, CartItem>
{
    private readonly ICartItemService _cartItemService;

    public GetCartItemByIdQueryHandler(ICartItemService cartItemService)
    {
        _cartItemService = cartItemService;
    }

    public Task<CartItem> Handle(GetCartItemByIdQuery request, CancellationToken cancellationToken)
    {
        return _cartItemService.GetByIdAsync(request, cancellationToken);
    }
}