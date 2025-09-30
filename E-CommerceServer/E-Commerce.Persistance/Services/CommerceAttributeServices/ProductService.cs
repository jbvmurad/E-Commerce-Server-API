using AutoMapper;
using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.CreateProduct;
using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.DeleteProduct;
using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.UpdateProduct;
using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Queries.GetAllProducts;
using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Queries.GetProductById;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using E_Commerce.Domain.Repositories.CommerceAttributeRepositories;
using GenericRepository;

namespace E_Commerce.Persistance.Services;

public sealed class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ProductService(IMapper mapper, IUnitOfWork unitOfWork, IProductRepository productRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }
    public async Task CreateAsync(CreateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = _mapper.Map<Product>(request);

        await _productRepository.AddAsync(product , cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FirstOrDefaultAsync(
            c => c.Id == request.Id,
            cancellationToken);

        if (product is null)
            throw new ArgumentException($"Product with ID {request.Id} not found.");

        _productRepository.Delete(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PagedList<Product>> GetAllAsync(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var productsQuery = _productRepository.GetAll();
        var pageParams = request.PageParameters;

        return await PagedList<Product>.CreateAsync(productsQuery, pageParams.PageNumber, pageParams.PageSize);
    }

    public async Task<Product> GetByIdAsync(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FirstOrDefaultAsync(
          c => c.Id == request.Id,
          cancellationToken);

        if (product is null)
            throw new ArgumentException($"Product with ID {request.Id} not found.");
        return product;
    }

    public async Task UpdateAsync(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.FirstOrDefaultAsync(
            c => c.Id == request.Id,
            cancellationToken);

        if (product is null)
            throw new ArgumentException($"Product with ID {request.Id} not found.");

        _mapper.Map(request, product);
        _productRepository.Update(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}