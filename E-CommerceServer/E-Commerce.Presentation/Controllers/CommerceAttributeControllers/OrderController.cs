using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Commands.Order;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Commands.UpdateOrder;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Queries.GetAllOrders;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Queries.GetOrderById;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using E_Commerce.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers.CommerceAtributeControllers;

[ApiController]
[Route("api/[controller]")]
public sealed class OrderController : APIController
{
    public OrderController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PageParameters parameters, CancellationToken cancellationToken)
    {
        var request = new GetAllOrdersQuery(parameters);
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id ,CancellationToken cancellationToken)
    {
        var request = new GetOrderByIdQuery(id);
        Order order = await _mediator.Send(request,cancellationToken);
        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> Order(OrderCommand request,CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
