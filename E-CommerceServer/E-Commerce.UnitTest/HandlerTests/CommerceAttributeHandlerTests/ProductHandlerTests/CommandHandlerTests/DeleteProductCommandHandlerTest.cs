using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.DeleteProduct;
using E_Commerce.Application.Services.CommerceAttributeServices;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.ProductHandlerTests.CommandHandlerTests;

public class DeleteProductCommandHandlerTest
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly DeleteProductCommandHandler _handler;

    public DeleteProductCommandHandlerTest()
    {
        _productServiceMock = new Mock<IProductService>();
        _handler = new DeleteProductCommandHandler(_productServiceMock.Object);
    }

    [Fact]
    public async Task Hand_Should_Call_CreateAsync_And_Return_Message()
    {
        //Arrange
        var request = new DeleteProductCommand(1);
        var cancellationToken = CancellationToken.None;

        //Act
        var result=await _handler.Handle(request, cancellationToken);

        //Assert
        _productServiceMock.Verify(s=>s.DeleteAsync(request,cancellationToken),Times.Once);
        Assert.Equal("Product deleted successfully.", result.Message);
    }
}
