using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Queries.GetAllProducts;

public sealed record GetAllProductsQuery(
    PageParameters PageParameters) :IRequest<PagedList<Product>>;
