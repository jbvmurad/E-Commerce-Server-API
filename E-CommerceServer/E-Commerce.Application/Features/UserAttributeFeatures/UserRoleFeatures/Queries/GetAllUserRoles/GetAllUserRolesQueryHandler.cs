using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Application.Services.UserAttributeServices;
using E_Commerce.Domain.Entities.UserAttributeEntities;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.UserRoleFeatures.Queries.GetAllUserRoles;

public class GetAllUserRolesQueryHandler : IRequestHandler<GetAllUserRolesQuery, PagedList<UserRole>>
{
    private readonly IUserRoleService _userRoleService;

    public GetAllUserRolesQueryHandler(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    public async Task<PagedList<UserRole>> Handle(GetAllUserRolesQuery request, CancellationToken cancellationToken)
    {
        return await _userRoleService.GetAllAsync(request, cancellationToken);
    }
}
