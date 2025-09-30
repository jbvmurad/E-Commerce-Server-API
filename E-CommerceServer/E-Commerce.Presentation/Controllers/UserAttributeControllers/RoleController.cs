using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.DeleteCategory;
using E_Commerce.Application.Features.UserAttributeFeatures.RoleFeatures.Commands.CreateRole;
using E_Commerce.Domain.DTOs;
using E_Commerce.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers.UserControllers;

[ApiController]
[Route("api/[controller]")]
public sealed class RoleController : APIController
{
    public RoleController(IMediator mediator) : base(mediator) { }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleCommand request,CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        DeleteCategoryCommand request = new(id);
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
