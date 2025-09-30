namespace E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.Login;

public sealed record LoginCommandResponse(
    string Token,
    string RefreshToken,
    DateTime? RefreshTokenExpires,
    int UserId);
