using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Queries.GetProductById;

public sealed record GetProductByIdQuery(
    int Id):IRequest<Product>;
