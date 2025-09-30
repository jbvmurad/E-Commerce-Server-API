using E_Commerce.Application.Features.UserAttributeFeatures.RoleFeatures.Commands.CreateRole;
using E_Commerce.Application.Features.UserAttributeFeatures.RoleFeatures.Commands.DeleteRole;

namespace E_Commerce.Application.Services.UserAttributeServices;

public interface IRoleService
{
    Task CreateAsync(CreateRoleCommand request);
    Task DeleteAsync(DeleteRoleCommand request);
}
