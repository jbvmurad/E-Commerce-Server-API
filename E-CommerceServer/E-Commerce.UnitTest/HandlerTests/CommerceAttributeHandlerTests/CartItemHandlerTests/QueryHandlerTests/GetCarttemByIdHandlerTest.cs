using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Queries.GetCartItemById;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.CartItemHandlerTests.QueryHandlerTests;

public class GetCarttemByIdHandlerTest
{
    private readonly Mock<ICartItemService> _cartItemServiceMock;
    private readonly GetCartItemByIdQueryHandler _handler;

    public GetCarttemByIdHandlerTest()
    {
        _cartItemServiceMock = new Mock<ICartItemService>();
        _handler = new GetCartItemByIdQueryHandler(_cartItemServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_GetByIdAsync_And_Return_CartItem()
    {
        // Arrange
        var cartItemId = 1;
        var query = new GetCartItemByIdQuery(cartItemId);

        var expectedCartItem = new CartItem
        {
            Id = cartItemId,
            CartId = 100,
            ProductId = 200,
            Quantity = 3,
            UnitPrice = 99.99m
        };

        _cartItemServiceMock
            .Setup(service => service.GetByIdAsync(query, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedCartItem);

        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedCartItem.Id, result.Id);
        Assert.Equal(expectedCartItem.CartId, result.CartId);
        Assert.Equal(expectedCartItem.ProductId, result.ProductId);
        Assert.Equal(expectedCartItem.Quantity, result.Quantity);
        Assert.Equal(expectedCartItem.UnitPrice, result.UnitPrice);

        _cartItemServiceMock.Verify(service =>
            service.GetByIdAsync(query, cancellationToken), Times.Once);
    }
}
