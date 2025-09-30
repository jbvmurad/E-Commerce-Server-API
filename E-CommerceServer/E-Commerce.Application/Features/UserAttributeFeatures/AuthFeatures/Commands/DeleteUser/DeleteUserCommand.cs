using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.DeleteUser;

public sealed record DeleteUserCommand(
    int Id):IRequest<MessageResponse>;
