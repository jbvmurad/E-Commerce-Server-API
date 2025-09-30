using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Queries.GetCategoryById;
using E_Commerce.Application.Services.CommerceAttributeServices;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.CategoryHandlerTests.QueryHandlerTests;

public class GetCategoryByIdHandlerTest
{
    private readonly Mock<ICategoryService> _categoryServiceMock;
    private readonly GetCategoryByIdQueryHandler _handler;

    public GetCategoryByIdHandlerTest()
    {
        _categoryServiceMock = new Mock<ICategoryService>();
        _handler = new GetCategoryByIdQueryHandler(_categoryServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Return_Category_When_Category_Exists()
    {
        // Arrange
        var categoryId = 1;
        var expectedCategory = new Category { Id = categoryId, Name = "Zara" };
        var query = new GetCategoryByIdQuery(categoryId);
        var cancellationToken = CancellationToken.None;

        _categoryServiceMock
            .Setup(service => service.GetByIdAsync(query, cancellationToken))
            .ReturnsAsync(expectedCategory);

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedCategory.Id, result.Id);
        Assert.Equal(expectedCategory.Name, result.Name);

        _categoryServiceMock.Verify(service =>
            service.GetByIdAsync(query, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task Handle_Should_Return_Null_When_Category_Does_Not_Exist()
    {
        // Arrange
        var query = new GetCategoryByIdQuery(99); 
        var cancellationToken = CancellationToken.None;

        _categoryServiceMock
            .Setup(service => service.GetByIdAsync(query, cancellationToken))
            .ReturnsAsync((Category)null!);

        // Act
        var result = await _handler.Handle(query, cancellationToken);

        // Assert
        Assert.Null(result);

        _categoryServiceMock.Verify(service =>
            service.GetByIdAsync(query, cancellationToken), Times.Once);
    }
}
