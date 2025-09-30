using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Command.CreateCart;

public sealed record CreateCartCommand(
    int UserId):IRequest<MessageResponse>;
