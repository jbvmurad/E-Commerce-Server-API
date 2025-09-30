using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.CreateProduct;
using E_Commerce.Application.Services.CommerceAttributeServices;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.ProductHandlerTests.CommandHandlerTests;

public class CreateProductCommandHandlerTest
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly CreateProductCommandHandler _handler;

    public CreateProductCommandHandlerTest()
    {
        _productServiceMock = new Mock<IProductService>();
        _handler = new CreateProductCommandHandler(_productServiceMock.Object);
    }

    [Fact]
    public async Task Hand_Should_Call_CreateAsync_And_Return_Message()
    {
        //Arrange
        var request = new CreateProductCommand("Zara", "http://wwww.image.com", "Description", 12, 125, 1);
        var cancellationToken=CancellationToken.None;

        //Act
        var result=await _handler.Handle(request, cancellationToken);

        //Assert
        _productServiceMock.Verify(s => s.CreateAsync(request, cancellationToken), Times.Once);
        Assert.Equal("Product created successfully.", result.Message);
    }
}
