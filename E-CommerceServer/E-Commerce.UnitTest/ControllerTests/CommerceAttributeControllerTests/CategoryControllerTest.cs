using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.CreateCategory;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.DeleteCategory;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Commands.UpdateCategory;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Queries.GetAllCategories;
using E_Commerce.Application.Features.CommerceAttributeFeatures.CategoryFeatures.Queries.GetCategoryById;
using E_Commerce.Application.Services.PaginationService;
using E_Commerce.Domain.DTOs;
using E_Commerce.Domain.Entities.CommerceAttributeEntities;
using E_Commerce.Presentation.Controllers.CommerceAtributeControllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace E_Commerce.UnitTest.ControllerTests.CommerceAttributeControllerTests;

public class CategoryControllerTest
{
    [Fact]
    public async Task Create_ReturnOkResult_WhenRequestIsValid()
    {
        //Arrange
        var mediatorMock = new Mock<IMediator>();
        CreateCategoryCommand createCategoryCommand = new(
            "Zara");
        MessageResponse response = new("Category created successfully.");
        CancellationToken cancellationToken = new();
        mediatorMock
            .Setup(m => m.Send(createCategoryCommand, cancellationToken))
            .ReturnsAsync(response);
        CategoryController categoryController = new(mediatorMock.Object);

        //Act
        var result = await categoryController.Create(createCategoryCommand, cancellationToken);

        //Asert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<MessageResponse>(okResult.Value);

        Assert.Equal(response, returnValue);
        mediatorMock.Verify(m => m.Send(createCategoryCommand, cancellationToken));
    }

    [Fact]
    public async Task GetById_ReturnsOk_WhenCategoryExists()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var category = new Category { Id = 1, Name = "Zara" };
        var cancellationToken = new CancellationToken();

        mediatorMock
            .Setup(m => m.Send(It.Is<GetCategoryByIdQuery>(q => q.Id == 1), cancellationToken))
            .ReturnsAsync(category);

        var controller = new CategoryController(mediatorMock.Object);

        // Act
        var result = await controller.GetById(1, cancellationToken);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Category>(okResult.Value);
        Assert.Equal(1, returnValue.Id);
        Assert.Equal("Zara", returnValue.Name);
    }

    [Fact]
    public async Task GetAll_ReturnsOk_WithListOfCategories()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var categories = new PagedList<Category>(
            new List<Category> { new() { Id = 1, Name = "Zara" } },
            page: 1,
            pageSize: 10,
            totalCount: 1
        );
        var cancellationToken = new CancellationToken();

        mediatorMock
            .Setup(m => m.Send(It.IsAny<GetAllCategoriesQuery>(), cancellationToken))
            .ReturnsAsync(categories);

        var controller = new CategoryController(mediatorMock.Object);

        // Act
        var result = await controller.GetAll(new PageParameters(), cancellationToken);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<PagedList<Category>>(okResult.Value);

        Assert.Single(returnValue.Items);
        Assert.Equal("Zara", returnValue.Items[0].Name);
    }


    [Fact]
    public async Task Update_ReturnsOk_WhenUpdateIsSuccessful()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var command = new UpdateCategoryCommand(1, "Zara Updated");
        var response = new MessageResponse("Category updated successfully.");
        var cancellationToken = new CancellationToken();

        mediatorMock
            .Setup(m => m.Send(command, cancellationToken))
            .ReturnsAsync(response);

        var controller = new CategoryController(mediatorMock.Object);

        // Act
        var result = await controller.Update(command, cancellationToken);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<MessageResponse>(okResult.Value);
        Assert.Equal("Category updated successfully.", returnValue.Message);
    }

    [Fact]
    public async Task Delete_ReturnsOk_WhenCategoryDeleted()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();
        var response = new MessageResponse("Category deleted successfully.");
        var cancellationToken = new CancellationToken();

        mediatorMock
            .Setup(m => m.Send(It.Is<DeleteCategoryCommand>(x => x.Id == 1), cancellationToken))
            .ReturnsAsync(response);

        var controller = new CategoryController(mediatorMock.Object);

        // Act
        var result = await controller.Delete(1, cancellationToken);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<MessageResponse>(okResult.Value);
        Assert.Equal("Category deleted successfully.", returnValue.Message);
    }

}
