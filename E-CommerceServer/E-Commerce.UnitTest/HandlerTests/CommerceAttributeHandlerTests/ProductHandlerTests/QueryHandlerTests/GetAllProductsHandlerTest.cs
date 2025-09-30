using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Queries.GetAllProducts;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using E_Commerce.Domain.Enums.CommerceAttributeEnums;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.ProductHandlerTests.QueryHandlerTests;

public class GetAllProductsHandlerTest
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly GetAllProductsQueryHandler _handler;

    public GetAllProductsHandlerTest()
    {
        _productServiceMock = new Mock<IProductService>();
        _handler = new GetAllProductsQueryHandler(_productServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_GetAllAsync_And_Return_Products()
    {
        // Arrange
        var pageParams = new PageParameters
        {
            PageNumber = 1,
            PageSize = 10
        };

        var query = new GetAllProductsQuery(pageParams);

        var mockProductsList = new PagedList<Product>(
            new List<Product>
            {
        new Product
        {
            Id = 1,
            Name = "Zara2",
            ImageUrl = "http://wwww.image2.com",
            Description = "Description2",
            Price = 223,
            Status = ProductStatus.Inactive,
            StockQuantity = 50,
            CategoryId = 3
        },
        new Product
        {
            Id = 2,
            Name = "Zara4",
            ImageUrl = "http://wwww.image4.com",
            Description = "Description5",
            Price = 223,
            Status = ProductStatus.Active,
            StockQuantity = 100,
            CategoryId = 3
        }
            },
            page: 1,
            pageSize: 10,
            totalCount: 2
        );


        _productServiceMock
            .Setup(service => service.GetAllAsync(query, It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockProductsList);

        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        //Assert 
        Assert.NotNull(result);
        Assert.Equal(2, result.TotalCount);
        Assert.Equal(2, result.Items.Count);
        Assert.Contains(result.Items, c => c.Name == "Zara2");
        Assert.Contains(result.Items, c => c.Name == "Zara4");

        _productServiceMock.Verify(service =>
            service.GetAllAsync(query, cancellationToken), Times.Once);
    }
}
