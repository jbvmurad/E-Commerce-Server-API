using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.DeleteCategory;

public sealed record DeleteCategoryCommand(
    int Id) : IRequest<MessageResponse>;

