using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.RoleFeatures.Commands.DeleteRole;

public sealed record DeleteRoleCommand(
    int Id):IRequest<MessageResponse>;
