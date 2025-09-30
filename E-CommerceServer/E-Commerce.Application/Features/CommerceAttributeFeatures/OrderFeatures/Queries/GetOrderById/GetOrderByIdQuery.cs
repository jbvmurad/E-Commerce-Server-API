using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Queries.GetOrderById;

public sealed record GetOrderByIdQuery(
    int Id):IRequest<Order>;
