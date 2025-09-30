using E_Commerce.Application.Services.UserAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.RegisterUser;

public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, MessageResponse>
{
    private readonly IAuthService _authService;

    public RegisterUserCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<MessageResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        await _authService.RegisterAsync(request);
        return new MessageResponse("User registered successfully");
    }
}
