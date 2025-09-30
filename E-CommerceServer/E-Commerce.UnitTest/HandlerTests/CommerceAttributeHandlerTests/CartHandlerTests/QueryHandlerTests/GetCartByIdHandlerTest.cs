using E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Queries.GetCartById;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.CartHandlerTests.QueryHandlerTests;

public class GetCartByIdHandlerTest
{
    private readonly Mock<ICartService> _cartServiceMock;
    private readonly GetCartByIdQueryHandler _handler;

    public GetCartByIdHandlerTest()
    {
        _cartServiceMock = new Mock<ICartService>();
        _handler = new GetCartByIdQueryHandler(_cartServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_GetByIdAsync_And_Return_Cart()
    {
        // Arrange
        int cartId = 1;
        var query = new GetCartByIdQuery(cartId);

        var expectedCart = new Cart
        {
            Id = cartId,
            UserId = 100,
            TotalAmount = 150m
        };

        _cartServiceMock
            .Setup(service => service.GetByIdAsync(query, It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedCart);

        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedCart.Id, result.Id);
        Assert.Equal(expectedCart.UserId, result.UserId);
        Assert.Equal(expectedCart.TotalAmount, result.TotalAmount);

        _cartServiceMock.Verify(service =>
            service.GetByIdAsync(query, cancellationToken), Times.Once);
    }
}
