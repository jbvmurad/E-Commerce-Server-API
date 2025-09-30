using AutoMapper;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Commands.Order;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Commands.UpdateOrder;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Queries.GetAllOrders;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Queries.GetOrderById;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using E_Commerce.Domain.Enums.CommerceAttributeEnums;
using E_Commerce.Domain.Repositories.CommerceAttributeRepositories;
using GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Persistance.Services;

public sealed class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderService(IMapper mapper, IOrderRepository orderRepository, ICartItemRepository cartItemRepository, ICartRepository cartRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
        _cartItemRepository = cartItemRepository;
        _cartRepository = cartRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedList<Order>> GetAllAsync(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var ordersQuery=_orderRepository.GetAll();
        var pageParams=request.PageParameters;
        return await PagedList<Order>.CreateAsync(ordersQuery, pageParams.PageNumber, pageParams.PageSize);
    }

    public async Task<Order> GetByIdAsync(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        if (order == null)
            throw new Exception("Order not found.");

        return order;
    }

    public async Task OrderAsync(OrderCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository
            .Where(c => c.UserId == request.UserId)
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(cancellationToken);

        if (cart is null || !cart.CartItems.Any())
            throw new Exception("Cart is empty. Order cannot be created.");

        var order = _mapper.Map<Order>(request);

        order.Status = OrderStatus.Pending;
        order.TotalAmount = cart.CartItems.Sum(ci => ci.Quantity * ci.UnitPrice);
        order.OrderItems = cart.CartItems.Select(ci => new OrderItem
        {
            ProductId = ci.ProductId,
            Quantity = ci.Quantity,
            UnitPrice = ci.UnitPrice
        }).ToList();

        await _orderRepository.AddAsync(order, cancellationToken);

        _cartItemRepository.DeleteRange(cart.CartItems);
        cart.TotalAmount = 0;

       _cartRepository.Update(cart);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateOrderAsync(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        if (order == null)
            throw new Exception("Order not found.");

        _mapper.Map(request, order);

        _orderRepository.Update(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
