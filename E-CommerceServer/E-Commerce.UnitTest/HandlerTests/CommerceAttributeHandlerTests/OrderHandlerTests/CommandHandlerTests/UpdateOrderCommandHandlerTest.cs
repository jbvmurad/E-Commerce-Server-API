using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Commands.UpdateOrder;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.Enums.CommerceAttributeEnums;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.OrderHandlerTests.CommandHandlerTests;

public class UpdateOrderCommandHandlerTest
{
    private readonly Mock<IOrderService> _orderServiceMock;
    private readonly UpdateOrderCommandHandler _handler;

    public UpdateOrderCommandHandlerTest()
    {
        _orderServiceMock = new Mock<IOrderService>();
        _handler = new UpdateOrderCommandHandler(_orderServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_UpdateOrderAsync_And_Return_MessageResponse()
    {
        // Arrange
        var command = new UpdateOrderCommand(
            Id: 1,
            Status: OrderStatus.Shipped);

        _orderServiceMock
            .Setup(service => service.UpdateOrderAsync(command, It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(command, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Order updated successfully.", result.Message);

        _orderServiceMock.Verify(service =>
            service.UpdateOrderAsync(command, cancellationToken), Times.Once);
    }
}
