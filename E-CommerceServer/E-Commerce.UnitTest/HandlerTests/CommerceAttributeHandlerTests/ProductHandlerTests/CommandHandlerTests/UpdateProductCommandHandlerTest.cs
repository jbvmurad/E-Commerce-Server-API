using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.UpdateProduct;
using E_Commerce.Application.Services.CommerceAttributeServices;
using Moq;

namespace E_Commerce.UnitTest.HandlerTests.CommerceAttributeHandlerTests.ProductHandlerTests.CommandHandlerTests;

public class UpdateProductCommandHandlerTest
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly UpdateProductCommandHandler _handler;

    public UpdateProductCommandHandlerTest()
    {
        _productServiceMock = new Mock<IProductService>();
        _handler = new UpdateProductCommandHandler(_productServiceMock.Object);
    }

    [Fact]
    public async Task Hand_Should_Call_UpdateAsync_And_Return_Message()
    {
        //Arrange
        var request = new UpdateProductCommand(1,"Zara2", "http://wwww.image2.com", "Description2", 223, Domain.Enums.CommerceAttributeEnums.ProductStatus.Inactive, 3,1 );
        var cancellationToken=CancellationToken.None;

        //Act
        var result=await _handler.Handle(request, cancellationToken);

        //Assert
        _productServiceMock.Verify(s=>s.UpdateAsync(request, cancellationToken),Times.Once);
        Assert.Equal("Product updated successfully.", result.Message);
    }
}
