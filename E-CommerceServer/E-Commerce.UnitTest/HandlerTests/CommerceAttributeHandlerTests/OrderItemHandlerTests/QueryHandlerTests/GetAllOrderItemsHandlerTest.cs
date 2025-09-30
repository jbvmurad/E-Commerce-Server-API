using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Queries.GetAllOrderItems;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.OrderItemHandlerTests.QueryHandlerTests;

public class GetAllOrderItemsHandlerTests
{
    private readonly Mock<IOrderItemService> _orderItemServiceMock;
    private readonly GetAllOrderItemsQueryHandler _handler;

    public GetAllOrderItemsHandlerTests()
    {
        _orderItemServiceMock = new Mock<IOrderItemService>();
        _handler = new GetAllOrderItemsQueryHandler(_orderItemServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_GetAllAsync_And_Return_OrderItems()
    {
        // Arrange
        var pageParams = new PageParameters
        {
            PageNumber = 1,
            PageSize = 10
        };

        var query = new GetAllOrderItemsQuery(pageParams);

        var mockOrderItemList = new PagedList<OrderItem>(
            new List<OrderItem>
            {
                new OrderItem
                {
                    Id = 1,
                    Quantity = 2,
                    UnitPrice = 50,
                    OrderId = 101,
                    ProductId = 201,
                    Product = new Product { Id = 201, Name = "Zara T-Shirt" }
                },
                new OrderItem
                {
                    Id = 2,
                    Quantity = 1,
                    UnitPrice = 100,
                    OrderId = 102,
                    ProductId = 202,
                    Product = new Product { Id = 202, Name = "Nike Shoes" }
                }
            },
            page: 1,
            pageSize: 10,
            totalCount: 2
        );

        _orderItemServiceMock
            .Setup(service => service.GetAllAsync(query, It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockOrderItemList);

        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.TotalCount);
        Assert.Equal(2, result.Items.Count);
        Assert.Contains(result.Items, i => i.Product.Name == "Zara T-Shirt");
        Assert.Contains(result.Items, i => i.Product.Name == "Nike Shoes");

        _orderItemServiceMock.Verify(service =>
            service.GetAllAsync(query, cancellationToken), Times.Once);
    }
}
