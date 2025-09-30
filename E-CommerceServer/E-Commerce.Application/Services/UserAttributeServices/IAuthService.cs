using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.DeleteUser;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.Login;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.RegisterUser;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.UpdateUser;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Queries.GetAllUsers;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Queries.GetUserById;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.DTOs;

namespace E_Commerce.Application.Services.UserAttributeServices;

public interface IAuthService
{
    Task RegisterAsync(RegisterUserCommand request);
    Task<LoginCommandResponse> LoginAsync(LoginCommand request,CancellationToken cancellationToken);
    Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(
        CreateNewTokenByRefreshTokenCommand request,CancellationToken cancellationToken);
    Task UpdateAsync(UpdateUserCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(DeleteUserCommand request, CancellationToken cancellationToken);
    Task<PagedList<UserParameters>> GetAllAsync(GetAllUserQuery request,CancellationToken cancellationToken);
    Task<UserParameters> GetByIdAsync(GetUserByIdQuery request,CancellationToken cancellationToken);
}
