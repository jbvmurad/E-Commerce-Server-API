using E_Commerce.Application.Services.UserAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.RoleFeatures.Commands.CreateRole;

public sealed class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, MessageResponse>
{
    private readonly IRoleService _roleService;

    public CreateRoleCommandHandler(IRoleService roleService)
    {
        _roleService = roleService;
    }

    public async Task<MessageResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        await _roleService.CreateAsync(request);
        return new MessageResponse ("Role registered successfully");
    }
}
