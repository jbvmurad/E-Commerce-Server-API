using E_Commerce.Application.Services.UserAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.UpdateUser;

public sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, MessageResponse>
{
    private readonly IAuthService _authService;

    public UpdateUserCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<MessageResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        await _authService.UpdateAsync(request, cancellationToken);
        return new MessageResponse("User updated successfully.");
    }
}
