using E_Commerce.Application.Services.UserAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.RoleFeatures.Commands.DeleteRole;

public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, MessageResponse>
{
    private readonly IRoleService _roleService;

    public DeleteRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<MessageResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        await _roleService.DeleteAsync(request);
        return new MessageResponse("Role deleted successfully");
    }
}
