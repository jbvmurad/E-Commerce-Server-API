using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.DeleteProduct;

public sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, MessageResponse>
{
    private readonly IProductService _productService;
    public DeleteProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<MessageResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _productService.DeleteAsync(request, cancellationToken);
        return new MessageResponse("Product deleted successfully.");
    }
}
