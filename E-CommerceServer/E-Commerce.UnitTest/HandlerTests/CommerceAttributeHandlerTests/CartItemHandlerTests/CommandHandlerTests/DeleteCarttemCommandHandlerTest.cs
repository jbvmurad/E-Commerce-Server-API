using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.DeleteCartItem;
using E_Commerce.Application.Services.CommerceAttributeServices;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.CartItemHandlerTests.CommandHandlerTests;

public class DeleteCartItemCommandHandlerTest
{
    private readonly Mock<ICartItemService> _cartItemServiceMock;
    private readonly DeleteCartItemCommandHandler _handler;

    public DeleteCartItemCommandHandlerTest()
    {
        _cartItemServiceMock = new Mock<ICartItemService>();
        _handler = new DeleteCartItemCommandHandler(_cartItemServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_DeleteAsync_And_Return_MessageResponse()
    {
        // Arrange
        var command = new DeleteCartItemCommand(Id: 1);

        _cartItemServiceMock
            .Setup(service => service.DeleteAsync(command, It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(command, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Cart item deleted successfully.", result.Message);

        _cartItemServiceMock.Verify(service =>
            service.DeleteAsync(command, cancellationToken), Times.Once);
    }
}
