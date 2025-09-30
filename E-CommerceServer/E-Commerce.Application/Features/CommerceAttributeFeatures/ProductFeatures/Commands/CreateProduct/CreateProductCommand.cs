using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    string ImageUrl,
    string Description,
    int StockQuantity,
    decimal Price,
    int CategoryId
    ):IRequest<MessageResponse>;