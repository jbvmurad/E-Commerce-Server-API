using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.UserRoleFeatures.Commands.GiveUserRole;

public sealed record GiveUserRoleCommand(
    int UserId,
    int RoleId):IRequest<MessageResponse>;
