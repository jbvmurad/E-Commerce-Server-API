using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.Login;
using E_Commerce.Application.Services.UserAttributeServices;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.CreateNewTokenByRefreshToken;

public sealed class CreateNewTokenByRefreshTokenCommandHandler : IRequestHandler<CreateNewTokenByRefreshTokenCommand, LoginCommandResponse>
{
    private readonly IAuthService _authService;

    public CreateNewTokenByRefreshTokenCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginCommandResponse> Handle(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _authService.CreateTokenByRefreshTokenAsync(request,cancellationToken);
        return response;
    }
}
