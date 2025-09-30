using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Queries.GetCategoryById;

public sealed record GetCategoryByIdQuery(
    int Id) : IRequest<Category>;

