using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Queries.GetCartById;

public sealed record GetCartByIdQuery(
    int Id) : IRequest<Cart>;