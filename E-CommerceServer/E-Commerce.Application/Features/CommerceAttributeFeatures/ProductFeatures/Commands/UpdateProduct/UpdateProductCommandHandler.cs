using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.UpdateProduct;

public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, MessageResponse>
{
    private readonly IProductService _productService;
    public UpdateProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<MessageResponse> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        await _productService.UpdateAsync(command, cancellationToken);
        return new MessageResponse("Product updated successfully.");
    }
}
