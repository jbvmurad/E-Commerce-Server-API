using E_Commerce.Application.Services.UserAttributeServices;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.Login;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
{
    private readonly IAuthService _authService;

    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _authService.LoginAsync(request,cancellationToken);
        return response;
    }
}
