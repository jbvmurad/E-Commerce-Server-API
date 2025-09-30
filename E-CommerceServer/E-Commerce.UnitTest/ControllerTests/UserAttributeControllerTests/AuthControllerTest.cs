using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.Login;
using E_Commerce.Application.Features.UserAttributeFeatures.AuthFeatures.Commands.RegisterUser;
using E_Commerce.Domain.DTOs;
using E_Commerce.Presentation.Controllers.UserControllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace E_Commerce.UnitTest.ControllerTests.UserAttributeControllerTests;

public class AuthControllerTest
{
    [Fact]
    public async Task Register_ReturnOkResult_WhenRequestIsValid()
    {
        //Arange
        var mediatorMock =new Mock<IMediator>();
        RegisterUserCommand registerUserCommand = new(
            "Murad", "Jabiyev", "muradaliyev@gmail.com", "Murad00", "+994556667788", "Mmmmmm150@");
        MessageResponse response = new("User registered successfully");
        CancellationToken cancellationToken = new ();
        mediatorMock
            .Setup(m=>m.Send(registerUserCommand,cancellationToken))
            .ReturnsAsync(response);
        AuthController authController = new(mediatorMock.Object);

        //Act
        var result = await authController.Register(registerUserCommand, cancellationToken);

        //Assert
        var okResult=Assert.IsType<OkObjectResult>(result);
        var returnValue=Assert.IsType<MessageResponse>(okResult.Value);

        Assert.Equal(response, returnValue);
        mediatorMock.Verify(m => m.Send(registerUserCommand, cancellationToken));
    }

    [Fact]
    public async Task Login_ReturnOkResult_WhenRequestIsValid()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();

        var loginCommand = new LoginCommand("muradaliyev@gmail.com", "Murad777@");

        var expectedResponse = new LoginCommandResponse(
            Token: "sample_token",
            RefreshToken: "sample_refresh_token",
            RefreshTokenExpires: DateTime.UtcNow.AddMinutes(15),
            UserId: 1
        );

        var cancellationToken = new CancellationToken();

        mediatorMock
            .Setup(m => m.Send(loginCommand, cancellationToken))
            .ReturnsAsync(expectedResponse);

        var authController = new AuthController(mediatorMock.Object);

        // Act
        var result = await authController.Login(loginCommand, cancellationToken);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var actualResponse = Assert.IsType<LoginCommandResponse>(okResult.Value);

        Assert.Equal(expectedResponse.Token, actualResponse.Token);
        Assert.Equal(expectedResponse.RefreshToken, actualResponse.RefreshToken);
        Assert.Equal(expectedResponse.RefreshTokenExpires, actualResponse.RefreshTokenExpires);
        Assert.Equal(expectedResponse.UserId, actualResponse.UserId);

        mediatorMock.Verify(m => m.Send(loginCommand, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task CreateNewTokenByRefreshToken_ReturnsOkResult_WhenRequestIsValid()
    {
        // Arrange
        var mediatorMock = new Mock<IMediator>();

        var command = new CreateNewTokenByRefreshTokenCommand(
            UserId: 1,
            RefreshToken: "valid_refresh_token"
        );

        var expectedResponse = new LoginCommandResponse(
            Token: "new_token",
            RefreshToken: "new_refresh_token",
            RefreshTokenExpires: DateTime.UtcNow.AddDays(7),
            UserId: 1
        );

        var cancellationToken = new CancellationToken();

        mediatorMock
            .Setup(m => m.Send(command, cancellationToken))
            .ReturnsAsync(expectedResponse);

        var authController = new AuthController(mediatorMock.Object);

        // Act
        var result = await authController.CreateTokenByRefreshToken(command, cancellationToken);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var actualResponse = Assert.IsType<LoginCommandResponse>(okResult.Value);

        Assert.Equal(expectedResponse.Token, actualResponse.Token);
        Assert.Equal(expectedResponse.RefreshToken, actualResponse.RefreshToken);
        Assert.Equal(expectedResponse.RefreshTokenExpires, actualResponse.RefreshTokenExpires);
        Assert.Equal(expectedResponse.UserId, actualResponse.UserId);

        mediatorMock.Verify(m => m.Send(command, cancellationToken), Times.Once);
    }

}
