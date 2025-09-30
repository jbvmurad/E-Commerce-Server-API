using E_Commerce.Application.Features.CommerceAttributeFeatures.OrderFeatures.Queries.GetAllOrders;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.OrderHandlerTests.QueryHandlerTests;

public class GetAllOrdersHandlerTest
{
    private readonly Mock<IOrderService> _orderServiceMock;
    private readonly GetAllOrdersQueryHandler _handler;

    public GetAllOrdersHandlerTest()
    {
        _orderServiceMock = new Mock<IOrderService>();
        _handler = new GetAllOrdersQueryHandler(_orderServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_GetAllAsync_And_Return_Orders()
    {
        // Arrange
        var pageParams = new PageParameters
        {
            PageNumber = 1,
            PageSize = 10
        };

        var query = new GetAllOrdersQuery(pageParams);

        var mockOrders = new PagedList<Order>(
            new List<Order>
            {
                new Order
                {
                    Id = 1,
                    ShippingAddress = "123 Test St",
                    TotalAmount = 150,
                    UserId = 1
                },
                new Order
                {
                    Id = 2,
                    ShippingAddress = "456 Sample Ave",
                    TotalAmount = 250,
                    UserId = 2
                }
            },
            page: 1,
            pageSize: 10,
            totalCount: 2
        );

        _orderServiceMock
            .Setup(service => service.GetAllAsync(query, It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockOrders);

        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.TotalCount);
        Assert.Equal(2, result.Items.Count);
        Assert.Contains(result.Items, o => o.ShippingAddress == "123 Test St");
        Assert.Contains(result.Items, o => o.ShippingAddress == "456 Sample Ave");

        _orderServiceMock.Verify(service =>
            service.GetAllAsync(query, cancellationToken), Times.Once);
    }
}
