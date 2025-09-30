using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Command.CreateOrderItem;

public sealed record CreateOrderItemCommand(
    int ProductId,
    int OrderId):IRequest<MessageResponse>;
