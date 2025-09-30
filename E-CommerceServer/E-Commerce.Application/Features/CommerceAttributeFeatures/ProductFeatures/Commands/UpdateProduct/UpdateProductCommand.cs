using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Enums.CommerceAttributeEnums;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.UpdateProduct;

public sealed record UpdateProductCommand(
   int Id,
   string Name,
   string ImageUrl,
   string Description,
   decimal Price,
   ProductStatus Status,
   int StockQuantity,
   int CategoryId) : IRequest<MessageResponse>;