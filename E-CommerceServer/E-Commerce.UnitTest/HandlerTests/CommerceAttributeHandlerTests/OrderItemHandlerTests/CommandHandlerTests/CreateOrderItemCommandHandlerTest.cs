using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderItemFeatures.Command.CreateOrderItem;
using E_Commerce.Application.Services.CommerceAttributeServices;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.OrderItemHandlerTests.CommandHandlerTests;

public class CreateOrderItemCommandHandlerTest
{
    private readonly Mock<IOrderItemService> _orderItemServiceMock;
    private readonly CreateOrderItemCommandHandler _handler;

    public CreateOrderItemCommandHandlerTest()
    {
        _orderItemServiceMock = new Mock<IOrderItemService>();
        _handler = new CreateOrderItemCommandHandler(_orderItemServiceMock.Object);
    }

    [Fact]
    public async Task Hand_Should_Can_CreateAsync_And_Return_Message()
    {
        //Arrange
        var request = new CreateOrderItemCommand(1, 1);
        var cancellationToken=CancellationToken.None;

        //Act
        var result=await _handler.Handle(request, cancellationToken);

        //Assert
        _orderItemServiceMock.Verify(s=>s.CreateAsync(request, cancellationToken),Times.Once);
        Assert.Equal("Order item created successfully.", result.Message);
    }
}
