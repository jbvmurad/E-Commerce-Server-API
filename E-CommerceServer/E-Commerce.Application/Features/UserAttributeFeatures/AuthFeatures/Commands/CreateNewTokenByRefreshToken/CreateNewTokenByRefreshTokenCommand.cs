using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.Login;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.CreateNewTokenByRefreshToken;

public sealed record CreateNewTokenByRefreshTokenCommand(
    int UserId,
    string RefreshToken):IRequest<LoginCommandResponse>;
