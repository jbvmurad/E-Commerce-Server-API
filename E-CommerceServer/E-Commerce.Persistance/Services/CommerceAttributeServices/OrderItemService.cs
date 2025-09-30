using AutoMapper;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Command.CreateOrderItem;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Queries.GetAllOrderItems;
using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Queries.GetOrderItemById;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using E_Commerce.Domain.Repositories.CommerceAttributeRepositories;
using GenericRepository;

namespace E_Commerce.Persistance.Services;

public sealed class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderItemService(IMapper mapper, IUnitOfWork unitOfWork, IOrderItemRepository orderItemRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _orderItemRepository = orderItemRepository;
    }

    public async Task CreateAsync(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        OrderItem orderItem= _mapper.Map<OrderItem>(request);
        await _orderItemRepository.AddAsync(orderItem,cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PagedList<OrderItem>> GetAllAsync(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
    {
        var orderItemsQuery = _orderItemRepository.GetAll();
        var pageParams = request.PageParameters;
        return await PagedList<OrderItem>.CreateAsync(orderItemsQuery, pageParams.PageNumber, pageParams.PageSize);
    }

    public async Task<OrderItem> GetByIdAsync(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
    {
        var orderItem = await _orderItemRepository.FirstOrDefaultAsync(
            c => c.Id == request.Id,
             cancellationToken);

        if (orderItem is null)
            throw new ArgumentException($"Order item with ID {request.Id} not found.");

        return orderItem;
    }
}
