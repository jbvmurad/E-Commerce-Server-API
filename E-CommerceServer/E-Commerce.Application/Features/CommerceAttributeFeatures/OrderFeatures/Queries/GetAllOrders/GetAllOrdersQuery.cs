using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Queries.GetAllOrders;

public sealed record  GetAllOrdersQuery(
     PageParameters PageParameters) :IRequest<PagedList<Order>>;

