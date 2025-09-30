using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Queries.GetAllUsers;

public sealed record GetAllUserQuery(
    PageParameters PageParameters) :IRequest<PagedList<UserParameters>>;
