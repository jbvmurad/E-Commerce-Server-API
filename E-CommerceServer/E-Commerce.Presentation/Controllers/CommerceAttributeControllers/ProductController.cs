using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.CreateProduct;
using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.DeleteProduct;
using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.UpdateProduct;
using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Queries.GetAllProducts;
using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Queries.GetProductById;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using E_Commerce.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers.CommerceAtributeControllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ProductController : APIController
{
    public ProductController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PageParameters parameters, CancellationToken cancellationToken)
    {
        var request = new GetAllProductsQuery(parameters);
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var request = new GetProductByIdQuery(id);
        Product product = await _mediator.Send(request, cancellationToken);
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id , CancellationToken cancellationToken)
    {
        DeleteProductCommand request = new(id);
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}
