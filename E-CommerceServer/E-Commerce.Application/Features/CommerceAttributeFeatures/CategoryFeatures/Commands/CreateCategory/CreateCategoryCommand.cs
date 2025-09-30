using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.CreateCategory;

public sealed record CreateCategoryCommand(
    string Name):IRequest<MessageResponse>;
