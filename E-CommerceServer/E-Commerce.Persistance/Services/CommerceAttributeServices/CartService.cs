using AutoMapper;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Command.CreateCart;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Queries.GetAllCarts;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Queries.GetCartById;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using E_Commerce.Domain.Repositories.CommerceAttributeRepositories;
using GenericRepository;

namespace E_Commerce.Persistance.Services;

public sealed class CartService : ICartService
{
    private readonly IMapper _mapper;
    private readonly ICartRepository _cartRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CartService(ICartRepository cartRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateCartCommand request, CancellationToken cancellationToken)
    {
        Cart cart = _mapper.Map<Cart>(request);

        await _cartRepository.AddAsync(cart, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PagedList<Cart>> GetAllAsync(GetAllCartsQuery request, CancellationToken cancellationToken)
    {
        var cartsQuery = _cartRepository.GetAll();
        var pageParams = request.PageParameters;
        return await PagedList<Cart>.CreateAsync(cartsQuery, pageParams.PageNumber, pageParams.PageSize);
    }

    public async Task<Cart> GetByIdAsync(GetCartByIdQuery request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.FirstOrDefaultAsync(
            c => c.Id == request.Id,
             cancellationToken);

        if (cart is null)
            throw new ArgumentException($"Cart with ID {request.Id} not found.");

        return cart;
    }
}
