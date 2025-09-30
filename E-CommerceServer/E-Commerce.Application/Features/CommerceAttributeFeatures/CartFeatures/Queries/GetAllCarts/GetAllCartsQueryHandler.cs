using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Queries.GetAllCarts;

public sealed class GetAllCartsQueryHandler : IRequestHandler<GetAllCartsQuery, PagedList<Cart>>
{
    private readonly ICartService _cartService;

    public GetAllCartsQueryHandler(ICartService cartService)
    {
        _cartService = cartService;
    }

    public async Task<PagedList<Cart>> Handle(GetAllCartsQuery request, CancellationToken cancellationToken)
    {
        return await _cartService.GetAllAsync(request, cancellationToken);

    }
}
