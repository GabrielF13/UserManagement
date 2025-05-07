using Moq;
using System;
using System.Threading.Tasks;
using UserManagement.Application.Services;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Interfaces.Services;
using UserManagement.Infra.Message;
using UserManagement.Infra.Repositories.Users;
using Xunit;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly Mock<IMessageBroker> _mockMessageBroker;
    private readonly UserService _service;

    public UserServiceTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockMessageBroker = new Mock<IMessageBroker>();
        _service = new UserService(_mockUserRepository.Object, _mockMessageBroker.Object);
    }

    [Fact]
    public async Task RegisterUserAsync_ShouldThrowException_WhenUserExists()
    {
        // Arrange
        var userDto = new UserDto { Name = "Test", Email = "test@example.com" };
        _mockUserRepository.Setup(r => r.GetByEmailAsync(userDto.Email)).ReturnsAsync(new User(userDto.Name, userDto.Email));

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => _service.RegisterUserAsync(userDto));
    }

    [Fact]
    public async Task DeleteUserAsync_ShouldReturnFalse_WhenUserNotFound()
    {
        // Arrange
        var id = Guid.NewGuid();
        _mockUserRepository.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((User)null);

        // Act
        var result = await _service.DeleteUserAsync(id);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task UpdateUserAsync_ShouldReturnTrue_WhenSuccessful()
    {
        // Arrange
        var id = Guid.NewGuid();
        var userDto = new UserDto { Name = "Updated", Email = "updated@example.com" };
        _mockUserRepository.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(new User(id, "Old", "old@example.com"));

        // Act
        var result = await _service.UpdateUserAsync(id, userDto);

        // Assert
        Assert.True(result);
    }
}
