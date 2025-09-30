using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Queries.GetAllCarts;

public sealed record GetAllCartsQuery(
    PageParameters PageParameters) : IRequest<PagedList<Cart>>;
