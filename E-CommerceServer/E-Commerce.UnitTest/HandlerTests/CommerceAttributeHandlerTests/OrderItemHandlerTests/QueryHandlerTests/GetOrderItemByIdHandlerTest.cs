using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Queries.GetOrderItemById;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.OrderItemHandlerTests.QueryHandlerTests;

public class GetOrderItemByIdHandlerTests
{
    private readonly Mock<IOrderItemService> _orderItemServiceMock;
    private readonly GetOrderItemByIdQueryHandler _handler;

    public GetOrderItemByIdHandlerTests()
    {
        _orderItemServiceMock = new Mock<IOrderItemService>();
        _handler = new GetOrderItemByIdQueryHandler(_orderItemServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_GetByIdAsync_And_Return_OrderItem()
    {
        // Arrange
        var orderItemId = 1;
        var query = new GetOrderItemByIdQuery(orderItemId);

        var expectedOrderItem = new OrderItem
        {
            Id = orderItemId,
            Quantity = 2,
            UnitPrice = 75,
            OrderId = 101,
            ProductId = 201,
            Product = new Product { Id = 201, Name = "Adidas Hoodie" }
        };

        _orderItemServiceMock
            .Setup(service => service.GetByIdAsync(query, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedOrderItem);

        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedOrderItem.Id, result.Id);
        Assert.Equal(expectedOrderItem.Quantity, result.Quantity);
        Assert.Equal(expectedOrderItem.UnitPrice, result.UnitPrice);
        Assert.Equal(expectedOrderItem.ProductId, result.ProductId);
        Assert.Equal("Adidas Hoodie", result.Product.Name);

        _orderItemServiceMock.Verify(service =>
            service.GetByIdAsync(query, cancellationToken), Times.Once);
    }
}
