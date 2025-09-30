using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Abstraction;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes ="Bearer")]
public abstract class APIController : ControllerBase
{
    public readonly IMediator _mediator;

    protected APIController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
