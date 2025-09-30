using AutoMapper;
using E_Commerce.Application.Abstractions;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.DeleteUser;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.Login;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.RegisterUser;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.UpdateUser;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Queries.GetAllUsers;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Queries.GetUserById;
using E_Commerce.Application.Services.MailService;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Application.Services.UserAttributeServices;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.UserAttributeEntities;
using E_Commerce.Domain.Repositories.UserAttributeRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Persistance.Services.UserAttributeServices;

public sealed class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly IAuthRepository _authRepository;
    private readonly IEmailService _emailService;
    private readonly IJwtProvider _jwtProvider;
    private readonly IMapper _mapper;

    public AuthService(UserManager<User> userManager, IMapper mapper, IAuthRepository authRepository, IEmailService emailService, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _mapper = mapper;
        _authRepository = authRepository;
        _emailService = emailService;
        _jwtProvider = jwtProvider;
    }

    public async Task<PagedList<UserParameters>> GetAllAsync(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var usersQuery = _authRepository.GetAll();

        var users = await PagedList<User>.CreateAsync(
            usersQuery,
            request.PageParameters.PageNumber,
            request.PageParameters.PageSize
        );

        var userDtos = _mapper.Map<List<UserParameters>>(users.Items);

        return new PagedList<UserParameters>(
            userDtos,
            users.Page,
            users.PageSize,
            users.TotalCount
        );
    }

    public async Task<UserParameters> GetByIdAsync(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _authRepository.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (user == null)
            throw new KeyNotFoundException($"User with ID {request.Id} not found.");

        return _mapper.Map<UserParameters>(user);
    }

    public async Task RegisterAsync(RegisterUserCommand request)
    {
        User user=_mapper.Map<User>(request);
        IdentityResult result=await _userManager.CreateAsync(user,request.Password);
        if (!result.Succeeded) 
        {
            throw new Exception(result.Errors.First().Description);
        }

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        await _emailService.SendVerificationEmailAsync(user.Email, user.Id.ToString(), token);
    }


    public async Task UpdateAsync(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id.ToString());

        if (user is null)
            throw new ArgumentException($"User with ID {request.Id} not found.");

        _mapper.Map(request, user);

        if (!string.IsNullOrEmpty(request.Password))
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, request.Password);

            if (!result.Succeeded)
                throw new Exception(result.Errors.First().Description);
        }

        var updateResult = await _userManager.UpdateAsync(user);
        if (!updateResult.Succeeded)
            throw new Exception(updateResult.Errors.First().Description);
    }

    public async Task DeleteAsync(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id.ToString());
        if (user is null)
            throw new ArgumentException($"User with ID {request.Id} not found.");

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
            throw new Exception(result.Errors.First().Description);

        await _emailService.SendDeletionNotificationEmailAsync(user.Email);
    }

    public async Task<LoginCommandResponse> LoginAsync(LoginCommand request,CancellationToken cancellationToken)
    {
        User user = await _userManager.Users.Where(p =>
         p.UserName==request.UserNameOrEmail || p.Email == request.UserNameOrEmail)
            .FirstOrDefaultAsync(cancellationToken);

        if (user is null) throw new ArgumentException("User not found");

        var result = await _userManager.CheckPasswordAsync(user, request.Password);
        if (result)
        {
            LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
            return response;
        }

        throw new ArgumentException("Incorrect password entered.");
    }

    public async Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        User user = await _userManager.FindByIdAsync(request.UserId.ToString());
        if (user is null) throw new ArgumentException("User not found");
        if (request.RefreshToken != request.RefreshToken) throw new ArgumentException("RefreshToken is invalid.");
        if (user.RefreshTokenExpires < DateTime.UtcNow) throw new ArgumentException("RefreshToken is expired");
        LoginCommandResponse response=await _jwtProvider.CreateTokenAsync(user);
        return response;
    }
}
