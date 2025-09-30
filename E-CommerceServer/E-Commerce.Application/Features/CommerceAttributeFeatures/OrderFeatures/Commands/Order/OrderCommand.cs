using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Commands.Order;

public sealed record OrderCommand(
    int UserId,
    string ShippingAddress): IRequest<MessageResponse>;
