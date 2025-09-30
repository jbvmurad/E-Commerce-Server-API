using E_Commerce.Application.Features.CommerceAttributeFeatures.CartFeatures.Queries.GetAllCarts;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.CartHandlerTests.QueryHandlerTests;

public class GetAllCartsHandlerTest
{
    private readonly Mock<ICartService> _cartServiceMock;
    private readonly GetAllCartsQueryHandler _handler;

    public GetAllCartsHandlerTest()
    {
        _cartServiceMock = new Mock<ICartService>();
        _handler = new GetAllCartsQueryHandler(_cartServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_GetAllAsync_And_Return_PagedListOfCarts()
    {
        // Arrange
        var pageParams = new PageParameters
        {
            PageNumber = 1,
            PageSize = 10
        };

        var query = new GetAllCartsQuery(pageParams);

        var carts = new List<Cart>
        {
            new Cart { Id = 1, UserId = 101, TotalAmount = 200m },
            new Cart { Id = 2, UserId = 102, TotalAmount = 350m }
        };

        var pagedList = new PagedList<Cart>(
            carts,
            pageParams.PageNumber,
            pageParams.PageSize,
            totalCount: carts.Count
        );

        _cartServiceMock
            .Setup(service => service.GetAllAsync(query, It.IsAny<CancellationToken>()))
            .ReturnsAsync(pagedList);

        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(carts.Count, result.TotalCount);
        Assert.Equal(carts.Count, result.Items.Count);
        Assert.Contains(result.Items, c => c.UserId == 101);
        Assert.Contains(result.Items, c => c.UserId == 102);

        _cartServiceMock.Verify(service =>
            service.GetAllAsync(query, cancellationToken), Times.Once);
    }
}
