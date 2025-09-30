using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.UpdateCategory;

public sealed record UpdateCategoryCommand(
    int Id,
    string Name) : IRequest<MessageResponse>;
