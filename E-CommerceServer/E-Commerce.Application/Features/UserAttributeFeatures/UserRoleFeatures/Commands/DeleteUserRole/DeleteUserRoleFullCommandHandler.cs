using MediatR;
using E_Commerce.Application.Services.UserAttributeServices;
using E_Commerce.Domain.DTOs;

namespace E_Commerce.Application.Features.UserAttributeFeatures.UserRoleFeatures.Commands.DeleteUserRole;

public sealed class DeleteUserRoleFullCommandHandler : IRequestHandler<DeleteUserRoleFullCommand, MessageResponse>
{
    private readonly IUserRoleService _userRoleService;

    public DeleteUserRoleFullCommandHandler(IUserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    public async Task<MessageResponse> Handle(DeleteUserRoleFullCommand request, CancellationToken cancellationToken)
    {
        await _userRoleService.DeleteAsync(request, cancellationToken);
        return new MessageResponse("Selected roles have been removed from the user.");
    }
}
