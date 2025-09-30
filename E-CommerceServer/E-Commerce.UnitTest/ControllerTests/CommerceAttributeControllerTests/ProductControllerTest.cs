using E_Commerce.Application.Features.CommerceAttributeFeatures.ProductFeatures.Commands.CreateProduct;
using E_Commerce.Domain.DTOs;
using E_Commerce.Presentation.Controllers.CommerceAtributeControllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace E_Commerce.UnitTest.ControllerTests.CommerceAttributeControllerTests;

public class ProductControllerTest
{
    [Fact]
    public async Task Create_ReturnOkResult_WhenRequestIsValid()
    {
        //Arange
        var mediatorMock=new Mock<IMediator>();
        CreateProductCommand createProductCommand = new(
            "Don" ,"https://en.wikipedia.org/wiki/Image#/media/File:Image_created_with_a_mobile_phone.png" ,"Description" ,10 ,13 ,1);
        MessageResponse response = new("Product created successfully.");
        CancellationToken cancellationToken = new ();
        mediatorMock
            .Setup(m=>m.Send(createProductCommand,cancellationToken))
            .ReturnsAsync(response);
        ProductController productController=new(mediatorMock.Object);

        //Act
        var result=await productController.Create(createProductCommand,cancellationToken);

        //Assert
        var okResut=Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<MessageResponse>(okResut.Value);

        Assert.Equal(response, returnValue);
        mediatorMock.Verify(m => m.Send(createProductCommand, cancellationToken));
    }
}
