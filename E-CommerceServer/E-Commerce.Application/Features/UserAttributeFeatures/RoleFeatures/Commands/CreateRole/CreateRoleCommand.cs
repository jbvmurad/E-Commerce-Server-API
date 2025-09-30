using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.UserAttributeFeatures.RoleFeatures.Commands.CreateRole;

public sealed record CreateRoleCommand(
    string Name):IRequest<MessageResponse>;
