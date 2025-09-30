using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.CreateCategory;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.DeleteCategory;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.UpdateCategory;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Queries.GetAllCategories;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Queries.GetCategoryById;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using E_Commerce.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentation.Controllers.CommerceAtributeControllers;
[ApiController]
[Route("api/[controller]")]
public sealed class CategoryController : APIController
{
    public CategoryController(IMediator mediator) : base(mediator) { }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] PageParameters parameters, CancellationToken cancellationToken)
    {
        var request = new GetAllCategoriesQuery(parameters);
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var request = new GetCategoryByIdQuery(id);
        Category category = await _mediator.Send(request, cancellationToken);
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand request ,CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(command, cancellationToken);
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
