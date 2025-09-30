using E_Commerce.Application.Features.UserAttributeFeatures.UserRoleFeatures.Commands.DeleteUserRole;
using E_Commerce.Application.Features.UserAttributeFeatures.UserRoleFeatures.Commands.GiveUserRole;
using E_Commerce.Application.Features.UserAttributeFeatures.UserRoleFeatures.Queries.GetAllUserRoles;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.UserAttributeEntities;

namespace E_Commerce.Application.Services.UserAttributeServices;

public interface IUserRoleService
{
    Task GiveAsync(GiveUserRoleCommand request, CancellationToken cancellationToken);
    Task<PagedList<UserRole>> GetAllAsync(GetAllUserRolesQuery request, CancellationToken cancellationToken);
    Task DeleteAsync(DeleteUserRoleFullCommand request, CancellationToken cancellationToken);
}
