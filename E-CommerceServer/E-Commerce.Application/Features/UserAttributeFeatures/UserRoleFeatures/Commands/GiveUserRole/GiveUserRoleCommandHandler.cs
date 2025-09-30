using E_Commerce.Application.Services.UserAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.UserRoleFeatures.Commands.GiveUserRole;

public sealed class GiveUserRoleCommandHandler : IRequestHandler<GiveUserRoleCommand, MessageResponse>
{
    private readonly IUserRoleService _userRoleService;

    public GiveUserRoleCommandHandler(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    public async Task<MessageResponse> Handle(GiveUserRoleCommand request, CancellationToken cancellationToken)
    {
        await _userRoleService.GiveAsync(request, cancellationToken);
        return new MessageResponse("The role has been successfully assigned to the user");
    }
}
