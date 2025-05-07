using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using UserManagement.API.Controllers;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Services;
using Xunit;

public class UserControllerTests
{
    private readonly Mock<IUserService> _mockUserService;
    private readonly UserController _controller;

    public UserControllerTests()
    {
        _mockUserService = new Mock<IUserService>();
        _controller = new UserController(_mockUserService.Object);
    }

    [Fact]
    public async Task GetUser_ShouldReturnOk_WhenUserExists()
    {
        // Arrange
        var id = Guid.NewGuid();
        var user = new UserDto { Name = "Test", Email = "test@example.com" };
        _mockUserService.Setup(s => s.GetByIdAsync(id)).ReturnsAsync(new User(id, user.Name, user.Email));

        // Act
        var result = await _controller.GetUser(id);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task RegisterUser_ShouldReturnCreated_WhenSuccessful()
    {
        // Arrange
        var userDto = new UserDto { Name = "Test", Email = "test@example.com" };
        var userId = Guid.NewGuid();
        _mockUserService.Setup(s => s.RegisterUserAsync(userDto)).ReturnsAsync(userId);

        // Act
        var result = await _controller.RegisterUser(userDto);

        // Assert
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(userId, createdResult.Value);
    }

    [Fact]
    public async Task UpdateUser_ShouldReturnOk_WhenSuccessful()
    {
        // Arrange
        var id = Guid.NewGuid();
        var userDto = new UserDto { Name = "Updated", Email = "updated@example.com" };
        _mockUserService.Setup(s => s.UpdateUserAsync(id, userDto)).ReturnsAsync(true);

        // Act
        var result = await _controller.UpdateUser(id, userDto);

        // Assert
        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task DeleteUser_ShouldReturnOk_WhenSuccessful()
    {
        // Arrange
        var id = Guid.NewGuid();
        _mockUserService.Setup(s => s.DeleteUserAsync(id)).ReturnsAsync(true);

        // Act
        var result = await _controller.DeleteUser(id);

        // Assert
        Assert.IsType<OkResult>(result);
    }
}
