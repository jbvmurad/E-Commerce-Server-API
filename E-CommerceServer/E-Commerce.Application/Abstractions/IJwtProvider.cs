using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.Login;
using E_Commerce.Domain.Entities.UserAttributeEntities;

namespace E_Commerce.Application.Abstractions;

public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateTokenAsync(User user);
}
