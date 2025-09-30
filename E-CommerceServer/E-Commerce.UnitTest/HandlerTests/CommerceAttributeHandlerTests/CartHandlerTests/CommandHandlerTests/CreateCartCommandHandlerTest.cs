using E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Command.CreateCart;
using E_Commerce.Application.Services.CommerceAttributeServices;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.CartHandlerTests.CommandHandlerTests;

public class CreateCartCommandHandlerTest
{
    private readonly Mock<ICartService> _cartServiceMock;
    private readonly CreateCartCommandHandler _handler;

    public CreateCartCommandHandlerTest()
    {
        _cartServiceMock = new Mock<ICartService>();
        _handler = new CreateCartCommandHandler(_cartServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_CreateAsync_And_Return_Success_Message()
    {
        // Arrange
        var command = new CreateCartCommand(UserId: 123);

        _cartServiceMock
            .Setup(service => service.CreateAsync(command, It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var cancellationToken = CancellationToken.None;

        // Act
        var response = await _handler.Handle(command, cancellationToken);

        // Assert
        Assert.NotNull(response);
        Assert.Equal("Cart created successfully.", response.Message);

        _cartServiceMock.Verify(service =>
            service.CreateAsync(command, cancellationToken), Times.Once);
    }
}
