using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Queries.GetCartById;

public sealed class GetCartByIdQueryHandler : IRequestHandler<GetCartByIdQuery, Cart>
{
    private readonly ICartService _cartService;

    public GetCartByIdQueryHandler(ICartService cartService)
    {
        _cartService = cartService;
    }

    public async Task<Cart> Handle(GetCartByIdQuery request, CancellationToken cancellationToken)
    {
        return await _cartService.GetByIdAsync(request, cancellationToken);
    }
}
