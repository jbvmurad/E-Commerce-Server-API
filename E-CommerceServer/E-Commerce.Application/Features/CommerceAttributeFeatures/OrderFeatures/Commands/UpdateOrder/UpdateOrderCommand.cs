using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Enums.CommerceAttributeEnums;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Commands.UpdateOrder;

public sealed record UpdateOrderCommand(
    int Id,
    OrderStatus Status): IRequest<MessageResponse>;
