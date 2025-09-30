using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Queries.GetAllCartItems;

public sealed record GetAllCartItemsQuery(
     PageParameters PageParameters) :IRequest<PagedList<CartItem>>;
