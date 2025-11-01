using Marketplace.Application.Users.Commands;
using Marketplace.Domain.Entities;
using Marketplace.Domain.Enums;
using Marketplace.Domain.Interface;
using Moq;

namespace Tests.Application.Users.Commands
{
    public class AddUserCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsId_WhenRepositoryAddsSuccessfully()
        {
            // Arrange
            var usersRepoMock = new Mock<IUsersRepository>();
            User? capturedUser = null;

            var returnedUser = new User
            {
                Id = 42,
                Username = "alice",
                Password = "irrelevant",
                Salt = "irrelevant",
                Name = "Alice",
                Email = "alice@example.com",
                Phone = "123",
                Balance = 0.0,
                Role = UserRole.Admin,
                IsActive = true
            };

            usersRepoMock
                .Setup(r => r.Add(It.IsAny<User>()))
                .Callback<User>(u => capturedUser = u)
                .ReturnsAsync(returnedUser);

            var handler = new AddUserCommandHandler(usersRepoMock.Object);

            var command = new AddUserCommand
            {
                Username = "alice",
                Password = "P@ssw0rd!",
                Name = "Alice",
                Email = "alice@example.com",
                Phone = "123",
                Role = "Admin"
            };

            // Act
            var resultId = await handler.Handle(command);

            // Assert
            Assert.Equal(returnedUser.Id, resultId);
            usersRepoMock.Verify(r => r.Add(It.IsAny<User>()), Times.Once);

            Assert.NotNull(capturedUser);
            Assert.Equal(command.Username, capturedUser!.Username);
            Assert.Equal(command.Name, capturedUser.Name);
            Assert.Equal(command.Email, capturedUser.Email);
            Assert.Equal(command.Phone, capturedUser.Phone);
            Assert.True(capturedUser.IsActive);

            // Password should be hashed (different from plain) and salt should be set
            Assert.False(string.IsNullOrEmpty(capturedUser.Password));
            Assert.NotEqual(command.Password, capturedUser.Password);
            Assert.False(string.IsNullOrEmpty(capturedUser.Salt));

            // Role should be parsed to enum
            Assert.Equal(UserRole.Admin, capturedUser.Role);
        }

        [Fact]
        public async Task Handle_ThrowsException_WhenRepositoryReturnsNull()
        {
            // Arrange
            var usersRepoMock = new Mock<IUsersRepository>();

            usersRepoMock
                .Setup(r => r.Add(It.IsAny<User>()))
                .ReturnsAsync((User?)null);

            var handler = new AddUserCommandHandler(usersRepoMock.Object);

            var command = new AddUserCommand
            {
                Username = "bob",
                Password = "secret",
                Name = "Bob",
                Email = "bob@example.com",
                Phone = "321",
                Role = "User"
            };

            // Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(() => handler.Handle(command));
            Assert.Equal("Failed to add user", ex.Message);
            usersRepoMock.Verify(r => r.Add(It.IsAny<User>()), Times.Once);
        }
    }
}