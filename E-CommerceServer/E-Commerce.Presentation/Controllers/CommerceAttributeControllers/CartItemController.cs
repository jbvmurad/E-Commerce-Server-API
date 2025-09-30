using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.CreateCartItem;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.DeleteCartItem;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.UpdateCartItem;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Queries.GetAllCartItems;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Queries.GetCartItemById;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using E_Commerce.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers.CommerceAtributeControllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CartItemController : APIController
{
    public CartItemController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PageParameters parameters, CancellationToken cancellationToken)
    {
        var request = new GetAllCartItemsQuery(parameters);
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var request = new GetCartItemByIdQuery(id);
        CartItem cartItem = await _mediator.Send(request, cancellationToken);
        return Ok(cartItem);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCartItemCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCartItemCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        DeleteCartItemCommand request = new(id);
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
