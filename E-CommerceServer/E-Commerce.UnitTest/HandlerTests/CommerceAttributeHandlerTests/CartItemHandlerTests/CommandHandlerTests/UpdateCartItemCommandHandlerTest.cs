using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.UpdateCartItem;
using E_Commerce.Application.Services.CommerceAttributeServices;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.CartItemHandlerTests.CommandHandlerTests;

public class UpdateCartItemCommandHandlerTest
{
    private readonly Mock<ICartItemService> _cartItemServiceMock;
    private readonly UpdateCartItemCommandHandler _handler;

    public UpdateCartItemCommandHandlerTest()
    {
        _cartItemServiceMock = new Mock<ICartItemService>();
        _handler = new UpdateCartItemCommandHandler(_cartItemServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_UpdateAsync_And_Return_MessageResponse()
    {
        // Arrange
        var command = new UpdateCartItemCommand(
            Id: 1,
            Quantity: 5
        );

        _cartItemServiceMock
            .Setup(service => service.UpdateAsync(command, It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(command, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Cart item updated successfully.", result.Message);

        _cartItemServiceMock.Verify(service =>
            service.UpdateAsync(command, cancellationToken), Times.Once);
    }
}
