using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.DeleteCategory;
using E_Commerce.Application.Services.CommerceAttributeServices;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.CategoryHandlerTests.CommandHandlerTests;

public class DeleteCategoryCommandHandlerTest
{
    private readonly Mock<ICategoryService> _categoryServiceMock;
    private readonly DeleteCategoryCommandHandler _handler;

    public DeleteCategoryCommandHandlerTest()
    {
        _categoryServiceMock = new Mock<ICategoryService>();
        _handler = new DeleteCategoryCommandHandler(_categoryServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_DeleteAsync_And_Return_Message()
    {
        // Arrange
        var request = new DeleteCategoryCommand(1);
        var cancellationToken = CancellationToken.None;

        // Act
        var result = await _handler.Handle(request, cancellationToken);

        // Assert
        _categoryServiceMock.Verify(s => s.DeleteAsync(request, cancellationToken), Times.Once);
        Assert.Equal("Category deleted successfully.", result.Message);
    }
}
