using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.CreateCartItem;

public sealed record  CreateCartItemCommand(
    int CartId,
    int ProductId,
    int Quantity,
    decimal UnitPrice):IRequest<MessageResponse>;
