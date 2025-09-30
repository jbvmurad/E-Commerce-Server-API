using E_Commerce.Application.Features.CommerceAttributeFeatures.CartItemFeatures.Queries.GetAllCartItems;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.CartItemHandlerTests.QueryHandlerTests;

public class GetAllCartItemsHandlerTest
{
    private readonly Mock<ICartItemService> _cartItemServiceMock;
    private readonly GetAllCartItemsQueryHandler _handler;

    public GetAllCartItemsHandlerTest()
    {
        _cartItemServiceMock = new Mock<ICartItemService>();
        _handler = new GetAllCartItemsQueryHandler(_cartItemServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_GetAllAsync_And_Return_CartItems()
    {
        // Arrange
        var pageParameters = new PageParameters
        {
            PageNumber = 1,
            PageSize = 10
        };

        var query = new GetAllCartItemsQuery(pageParameters);

        var mockCartItems = new PagedList<CartItem>(
            new List<CartItem>
            {
                new CartItem { Id = 1, CartId = 1, ProductId = 10, Quantity = 2, UnitPrice = 50m },
                new CartItem { Id = 2, CartId = 1, ProductId = 11, Quantity = 1, UnitPrice = 100m }
            },
            page: 1,
            pageSize: 10,
            totalCount: 2
        );

        _cartItemServiceMock
            .Setup(service => service.GetAllAsync(query, It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockCartItems);

        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.TotalCount);
        Assert.Equal(2, result.Items.Count);
        Assert.Contains(result.Items, item => item.ProductId == 10);
        Assert.Contains(result.Items, item => item.ProductId == 11);

        _cartItemServiceMock.Verify(service =>
            service.GetAllAsync(query, cancellationToken), Times.Once);
    }
}
