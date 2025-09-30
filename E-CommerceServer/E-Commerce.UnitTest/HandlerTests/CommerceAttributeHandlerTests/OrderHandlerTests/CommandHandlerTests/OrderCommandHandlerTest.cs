using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Commands.Order;
using E_Commerce.Application.Services.CommerceAttributeServices;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.OrderHandlerTests.CommandHandlerTests;

public class OrderCommandHandlerTest
{
    private readonly Mock<IOrderService> _orderServiceMock;
    private readonly OrderCommandHandler _handler;

    public OrderCommandHandlerTest()
    {
        _orderServiceMock = new Mock<IOrderService>();
        _handler = new OrderCommandHandler(_orderServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_OrderAsync_And_Return_MessageResponse()
    {
        // Arrange
        var command = new OrderCommand(
            UserId: 1,
            ShippingAddress: "123 Main Street, New York, NY");

        _orderServiceMock
            .Setup(service => service.OrderAsync(command, It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(command, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Order created successfully.", result.Message);

        _orderServiceMock.Verify(service =>
            service.OrderAsync(command, cancellationToken), Times.Once);
    }
}
