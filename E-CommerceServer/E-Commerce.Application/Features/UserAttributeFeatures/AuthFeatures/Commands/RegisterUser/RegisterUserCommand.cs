using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.RegisterUser;

public sealed record RegisterUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string UserName,
    string PhoneNumber,
    string Password) :IRequest<MessageResponse>;