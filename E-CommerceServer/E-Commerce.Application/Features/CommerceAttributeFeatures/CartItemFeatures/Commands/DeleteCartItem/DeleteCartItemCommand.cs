using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.DeleteCartItem;

public sealed record DeleteCartItemCommand(
    int Id) : IRequest<MessageResponse>;
