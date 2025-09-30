using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Command.CreateOrderItem;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Queries.GetAllOrderItems;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Queries.GetOrderItemById;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using E_Commerce.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers.CommerceAtributeControllers;

[ApiController]
[Route("api/[controller]")]
public sealed class OrderItemController : APIController
{
    public OrderItemController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PageParameters parameters, CancellationToken cancellationToken)
    {
        var request = new GetAllOrderItemsQuery(parameters);
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var request = new GetOrderItemByIdQuery(id);
        OrderItem orderItem = await _mediator.Send(request, cancellationToken);
        return Ok(orderItem);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
