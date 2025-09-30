using E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Command.CreateCart;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Queries.GetAllCarts;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Queries.GetCartById;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using E_Commerce.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers.CommerceAtributeControllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CartController : APIController
{
    public CartController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PageParameters parameters, CancellationToken cancellationToken)
    {
        var request = new GetAllCartsQuery(parameters);
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var request = new GetCartByIdQuery(id);
        Cart cart = await _mediator.Send(request, cancellationToken);
        return Ok(cart);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCartCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
