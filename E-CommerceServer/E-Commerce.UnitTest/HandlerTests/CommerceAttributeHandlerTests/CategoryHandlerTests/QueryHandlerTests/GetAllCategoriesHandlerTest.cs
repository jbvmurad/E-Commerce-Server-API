using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Queries.GetAllCategories;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.CategoryHandlerTests.QueryHandlerTests;

public class GetAllCategoriesHandlerTest
{
    private readonly Mock<ICategoryService> _categoryServiceMock;
    private readonly GetAllCategoriesQueryHandler _handler;

    public GetAllCategoriesHandlerTest()
    {
        _categoryServiceMock = new Mock<ICategoryService>();
        _handler = new GetAllCategoriesQueryHandler(_categoryServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_GetAllAsync_And_Return_Categories()
    {
        // Arrange
        var pageParams = new PageParameters
        {
            PageNumber = 1,
            PageSize = 10
        };

        var query = new GetAllCategoriesQuery(pageParams);

        var mockCategoryList = new PagedList<Category>(
            new List<Category>
            {
                new Category { Id = 1, Name = "Zara" },
                new Category { Id = 2, Name = "Nike" }
            },
            page: 1,
            pageSize: 10,
            totalCount: 2
        );

        _categoryServiceMock
            .Setup(service => service.GetAllAsync(query, It.IsAny<CancellationToken>()))
            .ReturnsAsync(mockCategoryList);

        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        //Assert 
        Assert.NotNull(result);
        Assert.Equal(2, result.TotalCount);
        Assert.Equal(2, result.Items.Count);
        Assert.Contains(result.Items, c => c.Name == "Zara");
        Assert.Contains(result.Items, c => c.Name == "Nike");

        _categoryServiceMock.Verify(service =>
            service.GetAllAsync(query, cancellationToken), Times.Once);
    }
}
