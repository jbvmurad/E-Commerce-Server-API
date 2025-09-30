using AutoMapper;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.CreateCartItem;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.DeleteCartItem;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.UpdateCartItem;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Queries.GetAllCartItems;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Queries.GetCartItemById;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using E_Commerce.Domain.Repositories.CommerceAttributeRepositories;
using GenericRepository;

namespace E_Commerce.Persistance.Services;

public sealed class CartItemService : ICartItemService
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CartItemService(IMapper mapper, ICartItemRepository cartItemRepository, IUnitOfWork unitOfWork, IProductRepository productRepository, ICartRepository cartRepository)
    {
        _mapper = mapper;
        _cartItemRepository = cartItemRepository;
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
        _cartRepository = cartRepository;
    }

    public async Task CreateAsync(CreateCartItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository
            .FirstOrDefaultAsync(c => c.Id == request.CartId, cancellationToken);

        if (cart is null)
            throw new ArgumentException($"Cart with ID {request.CartId} not found.");

        var product = await _productRepository
            .FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken);

        if (product is null)
            throw new ArgumentException($"Product with ID {request.ProductId} not found.");

        if (product.StockQuantity < request.Quantity)
            throw new ArgumentException("Insufficient stock.");

        var existingItem = await _cartItemRepository
            .FirstOrDefaultAsync(ci => ci.CartId == request.CartId && ci.ProductId == request.ProductId, cancellationToken);

        if (existingItem is not null)
        {
            existingItem.Quantity += request.Quantity;
            existingItem.UnitPrice = request.UnitPrice;
        }
        else
        {
            var cartItem = _mapper.Map<CartItem>(request);
            await _cartItemRepository.AddAsync(cartItem, cancellationToken);
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(UpdateCartItemCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await _cartItemRepository
            .FirstOrDefaultAsync(ci => ci.Id == request.Id, cancellationToken);

        if (cartItem is null)
            throw new ArgumentException($"Cart item with ID {request.Id} not found.");

        var product = await _productRepository
            .FirstOrDefaultAsync(p => p.Id == cartItem.ProductId, cancellationToken);

        if (product is null)
            throw new ArgumentException($"Product with ID {cartItem.ProductId} not found.");

        if (product.StockQuantity < request.Quantity)
            throw new ArgumentException("Insufficient stock.");

        _mapper.Map(request, cartItem);

        _cartItemRepository.Update(cartItem);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(DeleteCartItemCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await _cartItemRepository
            .FirstOrDefaultAsync(ci => ci.Id == request.Id, cancellationToken);

        if (cartItem is null)
            throw new ArgumentException($"Cart item with ID {request.Id} not found.");

        _cartItemRepository.Delete(cartItem);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PagedList<CartItem>> GetAllAsync(GetAllCartItemsQuery request, CancellationToken cancellationToken)
    {
        var cartItemsQuery = _cartItemRepository.GetAll();
        var pageParams = request.PageParameters;
        return await PagedList<CartItem>.CreateAsync(cartItemsQuery, pageParams.PageNumber, pageParams.PageSize);
    }

    public async Task<CartItem> GetByIdAsync(GetCartItemByIdQuery request, CancellationToken cancellationToken)
    {
        var cartItem = await _cartItemRepository
            .FirstOrDefaultAsync(ci => ci.Id == request.Id, cancellationToken);

        if (cartItem is null)
            throw new ArgumentException($"Cart item with ID {request.Id} not found.");
        return cartItem;
    }
}
