using Microsoft.EntityFrameworkCore;
using Moq;
using Otter.Core.Data;
using Otter.Core.DTOs;
using Otter.Core.Entities;
using Otter.Core.Interfaces;
using Otter.Core.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Otter.Tests;

public class AuthServiceTests
{
    private static OtterDbContext GetInMemoryDbContext()
    {
        var options = new DbContextOptionsBuilder<OtterDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new OtterDbContext(options);
    }

    [Fact]
    public async Task RegisterShouldThrowArgumentExceptionWhenEmailAlreadyExists()
    {
        var context = GetInMemoryDbContext();

        var mock = new Mock<ITokenService>();

        var user = new User
        {
            Id = 1,
            Email = "test@otter.com",
            Username = "OldUser",
            PasswordHash = "hash",
            RoleId = 1,
            Role = null!
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();

        var authService = new AuthService(context, mock.Object);

        var registerUserDto = new RegisterUserDto
        {
            Email = "test@otter.com",
            Username = "NewUser",
            Password = "password123"
        };

        var authAction = async () => await authService.Register(registerUserDto);

        var exception = await Assert.ThrowsAsync<ArgumentException>(authAction);

        Assert.Equal("Email is already in use!", exception.Message);
    }

    [Fact]
    public async Task LoginShouldThrowArgumentExceptionWhenUserIsNotRegistred()
    {
        var context = GetInMemoryDbContext();

        var mock = new Mock<ITokenService>();

        var authService = new AuthService(context, mock.Object);

        var loginUserDto = new LoginUserDto
        (
            "test@otter.com",
            "password123"
        );

        var authAction = async () => await authService.Login(loginUserDto);

        var exception = await Assert.ThrowsAsync<ArgumentException>(authAction);

        Assert.Equal("Email is incorrect!", exception.Message);
    }

    [Fact]
    public async Task RefreshTokenShouldThrowArgumentExeptionWhenTokenIsIncorrect()
    {
        var context = GetInMemoryDbContext();

        var mock = new Mock<ITokenService>();

        var authService = new AuthService(context, mock.Object);

        var user = new User
        {
            Id = 1,
            Email = "test@otter.com",
            Username = "OldUser",
            PasswordHash = "hash",
            RoleId = 1,
            Role = null!
        };

        var refreshToke = new UserRefreshToken
        {
            Id = 1,
            RefreshToken = "qeuqwgJB1231wefhe2112edwq12",
            UserId = 1,
        };

        context.Users.Add(user);
        context.UserRefreshToken.Add(refreshToke);
        await context.SaveChangesAsync();

        string token = "wewiejriowrho2i34kfnwoer";

        var authAction = async () => await authService.RefreshToken(token);

        var exception = await Assert.ThrowsAsync<ArgumentException>(authAction);

        Assert.Equal("Token is incorrect or not found.", exception.Message);
    }

    [Fact]
    public async Task RefreshTokenShouldThrowUnauthorizedAccessExceptionWhenTokenIsExpired()
    {
        var context = GetInMemoryDbContext();

        var mock = new Mock<ITokenService>();

        var authService = new AuthService(context, mock.Object);

        var role = new Role { Id = 1, RoleName = "User" };
        context.Roles.Add(role);

        var user = new User
        {
            Id = 1,
            Email = "test@otter.com",
            Username = "OldUser",
            PasswordHash = "hash",
            RoleId = 1,
            Role = null!
        };

        string token = "wewiejriowrho2i34kfnwoer";

        var refreshToke = new UserRefreshToken
        {
            RefreshToken = token,
            ExpirationTime = DateTime.UtcNow.AddDays(-9),
            UserId = 1,
            User = user
        };

        context.Users.Add(user);
        context.UserRefreshToken.Add(refreshToke);
        await context.SaveChangesAsync();

        var authAction = async () => await authService.RefreshToken(token);

        var exception = await Assert.ThrowsAsync<UnauthorizedAccessException>(authAction);

        Assert.Equal("Refresh token expired. Please login again.", exception.Message);
    }
}
