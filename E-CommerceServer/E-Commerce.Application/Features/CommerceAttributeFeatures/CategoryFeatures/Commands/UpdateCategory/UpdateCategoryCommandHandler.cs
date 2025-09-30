using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.UpdateCategory;

public sealed class UpdateCategoryCommandHandler :IRequestHandler<UpdateCategoryCommand, MessageResponse>
{
    private readonly ICategoryService _categoryService;
    public UpdateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    public async Task<MessageResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryService.UpdateAsync(request, cancellationToken);
        return new MessageResponse("Category updated successfully.");
    }
}
