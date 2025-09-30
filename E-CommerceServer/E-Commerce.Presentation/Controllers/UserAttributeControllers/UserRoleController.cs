using E_Commerce.Application.Features.UserAttributeFeatures.UserRoleFeatures.Commands.DeleteUserRole;
using E_Commerce.Application.Features.UserAttributeFeatures.UserRoleFeatures.Commands.GiveUserRole;
using E_Commerce.Application.Features.UserAttributeFeatures.UserRoleFeatures.Queries.GetAllUserRoles;
using E_Commerce.Domain.DTOs;
using E_Commerce.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers.UserControllers;

[ApiController]
[Route("api/[controller]")]
public sealed class UserRoleController : APIController
{
    public UserRoleController(IMediator mediator) : base(mediator) { }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteRoles([FromRoute] int userId, [FromBody] DeleteUserRoleBody body)
    {
        var command = new DeleteUserRoleFullCommand(userId, body.RoleIds);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(GiveUserRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PageParameters parameters, CancellationToken cancellationToken)
    {
        var request = new GetAllUserRolesQuery(parameters);
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }
}
