using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Commands.CreateCartItem;
using E_Commerce.Application.Services.CommerceAttributeServices;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.CartItemHandlerTests.CommandHandlerTests;

public class CreateCartItemCommandHandlerTest
{
    private readonly Mock<ICartItemService> _cartItemServiceMock;
    private readonly CreateCartItemCommandHandler _handler;

    public CreateCartItemCommandHandlerTest()
    {
        _cartItemServiceMock = new Mock<ICartItemService>();
        _handler = new CreateCartItemCommandHandler(_cartItemServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_CreateAsync_And_Return_MessageResponse()
    {
        // Arrange
        var command = new CreateCartItemCommand(
            CartId: 1,
            ProductId: 10,
            Quantity: 3,
            UnitPrice: 99.99m);

        _cartItemServiceMock
            .Setup(service => service.CreateAsync(command, It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(command, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Cart item created successfully.", result.Message);

        _cartItemServiceMock.Verify(service =>
            service.CreateAsync(command, cancellationToken), Times.Once);
    }
}
