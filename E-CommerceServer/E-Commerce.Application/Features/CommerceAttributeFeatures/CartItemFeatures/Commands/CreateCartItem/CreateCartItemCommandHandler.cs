using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.CreateCartItem;

public sealed class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, MessageResponse>
{
    private readonly ICartItemService _cartItemService;
    public CreateCartItemCommandHandler(ICartItemService cartItemService)
    {
        _cartItemService = cartItemService;
    }
    public async Task<MessageResponse> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
    {
        await _cartItemService.CreateAsync(request, cancellationToken);
        return new MessageResponse("Cart item created successfully.");
    }
}
