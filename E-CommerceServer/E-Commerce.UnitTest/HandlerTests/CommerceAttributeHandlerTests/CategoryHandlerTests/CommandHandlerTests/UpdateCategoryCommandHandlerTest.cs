using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.UpdateCategory;
using E_Commerce.Application.Services.CommerceAttributeServices;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.CategoryHandlerTests.CommandHandlerTests;

public class UpdateCategoryCommandHandlerTest
{
    private readonly Mock<ICategoryService> _categoryServiceMock;
    private readonly UpdateCategoryCommandHandler _handler;

    public UpdateCategoryCommandHandlerTest()
    {
        _categoryServiceMock = new Mock<ICategoryService>();
        _handler = new UpdateCategoryCommandHandler(_categoryServiceMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Call_UpdateAsync_And_Return_Message()
    {
        //Arrange
        var request = new UpdateCategoryCommand(1,"Donic");
        var cancellationToken=CancellationToken.None;

        //Act
        var result=await _handler.Handle(request, cancellationToken);

        //Assert
        _categoryServiceMock.Verify(s => s.UpdateAsync(request, cancellationToken), Times.Once);
        Assert.Equal("Category updated successfully.", result.Message);

    }
}
