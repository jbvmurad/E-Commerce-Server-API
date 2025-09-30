using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Command.CreateCart;

public sealed class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, MessageResponse>
{
    private readonly ICartService _cartService;

    public CreateCartCommandHandler(ICartService cartService)
    {
        _cartService = cartService;
    }

    public async Task<MessageResponse> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        await _cartService.CreateAsync(request, cancellationToken);
        return new MessageResponse("Cart created successfully.");
    }
}
