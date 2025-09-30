using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.UpdateCartItem
{
    public sealed record UpdateCartItemCommand(
        int Id,
        int Quantity) : IRequest<MessageResponse>;
}
