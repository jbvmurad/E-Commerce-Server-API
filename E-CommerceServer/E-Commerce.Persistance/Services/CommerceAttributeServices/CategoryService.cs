using AutoMapper;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.CreateCategory;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.DeleteCategory;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.UpdateCategory;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Queries.GetAllCategories;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Queries.GetCategoryById;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using E_Commerce.Domain.Repositories.CommerceAttributeRepositories;
using GenericRepository;

public sealed class CategoryService : ICategoryService
{

    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }

    public async Task CreateAsync(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = _mapper.Map<Category>(request);
        await _categoryRepository.AddAsync(category, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.FirstOrDefaultAsync(
            c => c.Id == request.Id,
            cancellationToken);

        if (category is null)
            throw new ArgumentException($"Category with ID {request.Id} not found.");

        _categoryRepository.Delete(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PagedList<Category>> GetAllAsync(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categoriesQuery = _categoryRepository.GetAll();
        var pageParams = request.PageParameters;

        return await PagedList<Category>.CreateAsync(categoriesQuery, pageParams.PageNumber, pageParams.PageSize);
    }

    public async Task<Category> GetByIdAsync(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _categoryRepository.FirstOrDefaultAsync(
             c => c.Id == request.Id,
             cancellationToken);

        if (product is null)
            throw new ArgumentException($"Category with ID {request.Id} not found.");
        return product;
    }

    public async Task UpdateAsync(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.FirstOrDefaultAsync(
            c => c.Id == request.Id,
            cancellationToken);

        if (category is null)
            throw new ArgumentException($"Category with ID {request.Id} not found.");

        _mapper.Map(request, category);
        _categoryRepository.Update(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
