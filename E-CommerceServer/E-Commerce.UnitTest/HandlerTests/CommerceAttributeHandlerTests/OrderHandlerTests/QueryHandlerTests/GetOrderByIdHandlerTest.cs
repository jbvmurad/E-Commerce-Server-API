using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Queries.GetOrderById;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.OrderHandlerTests.QueryHandlerTests;

public class GetOrderByIdHandlerTest
{
    private readonly Mock<IOrderService> _orderServiceMock;
    private readonly GetOrderByIdQueryHandler _handler;

    public GetOrderByIdHandlerTest()
    {
        _orderServiceMock = new Mock<IOrderService>();
        _handler = new GetOrderByIdQueryHandler(_orderServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_GetByIdAsync_And_Return_Order()
    {
        // Arrange
        var orderId = 1;
        var query = new GetOrderByIdQuery(orderId);

        var expectedOrder = new Order
        {
            Id = orderId,
            ShippingAddress = "123 Test Street",
            TotalAmount = 199.99m,
            UserId = 5
        };

        _orderServiceMock
            .Setup(service => service.GetByIdAsync(query, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedOrder);

        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedOrder.Id, result.Id);
        Assert.Equal(expectedOrder.ShippingAddress, result.ShippingAddress);
        Assert.Equal(expectedOrder.TotalAmount, result.TotalAmount);
        Assert.Equal(expectedOrder.UserId, result.UserId);

        _orderServiceMock.Verify(service =>
            service.GetByIdAsync(query, cancellationToken), Times.Once);
    }
}
