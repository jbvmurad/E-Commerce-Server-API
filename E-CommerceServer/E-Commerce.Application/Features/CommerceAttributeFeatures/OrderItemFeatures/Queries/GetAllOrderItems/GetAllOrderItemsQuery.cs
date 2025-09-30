using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Queries.GetAllOrderItems;

public sealed record GetAllOrderItemsQuery(
    PageParameters PageParameters) :IRequest<PagedList<OrderItem>>;
