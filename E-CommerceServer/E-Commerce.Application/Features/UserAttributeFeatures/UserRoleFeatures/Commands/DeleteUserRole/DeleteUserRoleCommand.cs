namespace E_Commerce.Application.Features.UserAttributeFeatures.UserRoleFeatures.Commands.DeleteUserRole;

public sealed record DeleteUserRoleCommand(
    List<int> RoleIds);
