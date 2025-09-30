using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.DeleteCategory;

public sealed class DeleteCategoryCommandHandler:IRequestHandler<DeleteCategoryCommand, MessageResponse>
{
    private readonly ICategoryService _categoryService;
    public DeleteCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    public async Task<MessageResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryService.DeleteAsync(request, cancellationToken);
        return new MessageResponse("Category deleted successfully.");
    }
}

