using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.UserAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.UserRoleFeatures.Queries.GetAllUserRoles;

public sealed record GetAllUserRolesQuery(
    PageParameters PageParameters):IRequest<PagedList<UserRole>>;

