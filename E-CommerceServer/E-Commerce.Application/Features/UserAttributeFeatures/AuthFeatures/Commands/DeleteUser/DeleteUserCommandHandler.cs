using E_Commerce.Application.Services.UserAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, MessageResponse>
{
    private readonly IAuthService _authService;

    public DeleteUserCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<MessageResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _authService.DeleteAsync(request, cancellationToken);
        return new MessageResponse("User deleted successfully.");
    }
}
