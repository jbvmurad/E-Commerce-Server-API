using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.CreateCategory;
using E_Commerce.Application.Services.CommerceAttributeServices;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.CategoryHandlerTests.CommandHandlerTests;
public class CreateCategoryCommandHandlerTest
{
    private readonly Mock<ICategoryService> _categoryServiceMock;
    private readonly CreateCategoryCommandHandler _handler;

    public CreateCategoryCommandHandlerTest()
    {
        _categoryServiceMock = new Mock<ICategoryService>();
        _handler = new CreateCategoryCommandHandler(_categoryServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_CreateAsync_And_Return_Message()
    {
        // Arrange
        var request = new CreateCategoryCommand("Zara");
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(request, cancellationToken);

        // Assert
        _categoryServiceMock.Verify(s => s.CreateAsync(request, cancellationToken), Times.Once);
        Assert.Equal("Category created successfully.", result.Message);
    }
}

