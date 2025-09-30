using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.DeleteCartItem;

public sealed class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommand, MessageResponse>
{
    private readonly ICartItemService _cartItemService;
    public DeleteCartItemCommandHandler(ICartItemService cartItemService)
    {
        _cartItemService = cartItemService;
    }
    public async Task<MessageResponse> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
    {
        await _cartItemService.DeleteAsync(request, cancellationToken);
        return new MessageResponse("Cart item deleted successfully.");
    }
}
