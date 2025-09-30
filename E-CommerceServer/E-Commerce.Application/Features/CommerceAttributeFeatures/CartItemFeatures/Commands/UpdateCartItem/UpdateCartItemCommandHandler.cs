using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.UpdateCartItem;

public sealed class UpdateCartItemCommandHandler : IRequestHandler<UpdateCartItemCommand, MessageResponse>
{
    private readonly ICartItemService _cartItemService;
    public UpdateCartItemCommandHandler(ICartItemService cartItemService)
    {
        _cartItemService = cartItemService;
    }
    public async Task<MessageResponse> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
    {
        await _cartItemService.UpdateAsync(request, cancellationToken);
        return new MessageResponse("Cart item updated successfully.");
    }
}
