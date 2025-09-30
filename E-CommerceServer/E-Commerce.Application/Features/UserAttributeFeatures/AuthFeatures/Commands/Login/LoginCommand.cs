using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.Login;

public sealed record LoginCommand(
    string UserNameOrEmail,
    string Password):IRequest<LoginCommandResponse>;
