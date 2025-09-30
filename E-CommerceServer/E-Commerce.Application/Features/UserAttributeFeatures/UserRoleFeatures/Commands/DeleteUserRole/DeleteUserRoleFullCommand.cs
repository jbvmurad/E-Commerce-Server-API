using MediatR;
using E_Commerce.Domain.DTOs;

namespace E_Commerce.Application.Features.UserAttributeFeatures.UserRoleFeatures.Commands.DeleteUserRole;

public sealed record DeleteUserRoleFullCommand(
    int UserId,
    List<int> RoleIds
) : IRequest<MessageResponse>;
