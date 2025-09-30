using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.DTOs;
using MediatR;

namespace E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.CreateCategory;

public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand , MessageResponse>
{
    private readonly ICategoryService _categoryService;
    public CreateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    public async Task<MessageResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryService.CreateAsync(request, cancellationToken);
        return new MessageResponse("Category created successfully.");
    }
}
