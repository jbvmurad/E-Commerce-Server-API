using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.DeleteUser;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.Login;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.RegisterUser;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.UpdateUser;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Queries.GetAllUsers;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Queries.GetUserById;
using E_Commerce.Domain.DTOs;
using E_Commerce.Infrastructure.Authorization;
using E_Commerce.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers.UserControllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuthController : APIController
{
    public AuthController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PageParameters parameters, CancellationToken cancellationToken)
    {
        var request = new GetAllUserQuery(parameters);
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var request = new GetUserByIdQuery(id);
        UserParameters user = await _mediator.Send(request, cancellationToken);
        return Ok(user);
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response=await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("createtoken")]
    public async Task<IActionResult> CreateTokenByRefreshToken(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        DeleteUserCommand request = new(id);
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}
