using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.CreateProduct;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, MessageResponse>
{
    private readonly IProductService _productService;
    public CreateProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }
    public async Task<MessageResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _productService.CreateAsync(request, cancellationToken);
        return new MessageResponse("Product created successfully.");
    }
}
