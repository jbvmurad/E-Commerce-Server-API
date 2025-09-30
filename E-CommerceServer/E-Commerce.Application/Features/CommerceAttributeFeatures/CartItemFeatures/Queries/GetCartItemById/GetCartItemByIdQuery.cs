using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Queries.GetCartItemById;

public sealed record  GetCartItemByIdQuery(
    int Id):IRequest<CartItem>;
