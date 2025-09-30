using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.DeleteProduct;

public sealed record DeleteProductCommand(
    int Id
    ):IRequest<MessageResponse>;

