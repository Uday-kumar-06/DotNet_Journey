using FinanceBilling.Core.DTOs.Auth;
using FinanceBilling.Core.Entities;
using FinanceBilling.Core.Interfaces.Repositories;
using FinanceBilling.Core.Interfaces.Services;
using FinanceBilling.Core.Services;
using Moq;

namespace FinanceBilling.Tests;

public class AuthServiceTests
{
    private readonly Mock<IUserRepository> _userRepoMock;
    private readonly Mock<IPasswordService> _passwordServiceMock;
    private readonly Mock<IJwtTokenService> _jwtTokenServiceMock;
    private readonly AuthService _sut;

    public AuthServiceTests()
    {
        _userRepoMock = new Mock<IUserRepository>();
        _passwordServiceMock = new Mock<IPasswordService>();
        _jwtTokenServiceMock = new Mock<IJwtTokenService>();

        _sut = new AuthService(
            _userRepoMock.Object,
            _passwordServiceMock.Object,
            _jwtTokenServiceMock.Object);
    }

    [Fact]
    public async Task RegisterAsync_WhenUsernameAlreadyExists_ThrowsException()
    {
        var dto = new RegisterRequestDto
        {
            Username = "alice",
            Email = "alice@example.com",
            Password = "pass"
        };

        _userRepoMock.Setup(r => r.GetByUsernameAsync("alice"))
            .ReturnsAsync(new User { Username = "alice" });

        var ex = await Assert.ThrowsAsync<Exception>(
            () => _sut.RegisterAsync(dto));

        Assert.Equal("Username already exists.", ex.Message);
    }

    [Fact]
    public async Task RegisterAsync_WhenEmailAlreadyExists_ThrowsException()
    {
        var dto = new RegisterRequestDto
        {
            Username = "bob",
            Email = "taken@example.com",
            Password = "pass"
        };

        _userRepoMock.Setup(r => r.GetByUsernameAsync("bob"))
            .ReturnsAsync((User?)null);

        _userRepoMock.Setup(r => r.GetByEmailAsync("taken@example.com"))
            .ReturnsAsync(new User
            {
                Email = "taken@example.com"
            });

        var ex = await Assert.ThrowsAsync<Exception>(
            () => _sut.RegisterAsync(dto));

        Assert.Equal("Email already exists.", ex.Message);
    }

    [Fact]
    public async Task RegisterAsync_WithValidData_AddsNewUser()
    {
        var dto = new RegisterRequestDto
        {
            Username = "charlie",
            Email = "charlie@example.com",
            Password = "secret"
        };

        _userRepoMock.Setup(r => r.GetByUsernameAsync("charlie"))
            .ReturnsAsync((User?)null);

        _userRepoMock.Setup(r => r.GetByEmailAsync("charlie@example.com"))
            .ReturnsAsync((User?)null);

        _passwordServiceMock.Setup(p => p.HashPassword("secret"))
            .Returns("hashed_secret");

        await _sut.RegisterAsync(dto);

        _userRepoMock.Verify(r => r.AddAsync(It.Is<User>(u =>
            u.Username == "charlie" &&
            u.Email == "charlie@example.com" &&
            u.PasswordHash == "hashed_secret" &&
            u.IsApproved == false &&
            u.IsActive == true)), Times.Once);
    }

    [Fact]
    public async Task LoginAsync_WhenUserNotFound_ReturnsNull()
    {
        var dto = new LoginRequestDto
        {
            Username = "ghost",
            Password = "any"
        };

        _userRepoMock.Setup(r => r.GetByUsernameAsync("ghost"))
            .ReturnsAsync((User?)null);

        var result = await _sut.LoginAsync(dto);

        Assert.Null(result);
    }

    [Fact]
    public async Task LoginAsync_WhenUserNotApproved_ThrowsException()
    {
        var dto = new LoginRequestDto
        {
            Username = "pending",
            Password = "pass"
        };

        _userRepoMock.Setup(r => r.GetByUsernameAsync("pending"))
            .ReturnsAsync(new User
            {
                Username = "pending",
                IsApproved = false
            });

        var ex = await Assert.ThrowsAsync<Exception>(
            () => _sut.LoginAsync(dto));

        Assert.Equal("Account pending approval.", ex.Message);
    }

    [Fact]
    public async Task LoginAsync_WhenPasswordInvalid_ReturnsNull()
    {
        var dto = new LoginRequestDto
        {
            Username = "alice",
            Password = "wrong"
        };

        _userRepoMock.Setup(r => r.GetByUsernameAsync("alice"))
            .ReturnsAsync(new User
            {
                Username = "alice",
                IsApproved = true,
                PasswordHash = "hashed"
            });

        _passwordServiceMock.Setup(p => p.VerifyPassword("wrong", "hashed"))
            .Returns(false);

        var result = await _sut.LoginAsync(dto);

        Assert.Null(result);
    }

    [Fact]
    public async Task LoginAsync_WithValidCredentials_ReturnsTokenResponse()
    {
        var dto = new LoginRequestDto
        {
            Username = "alice",
            Password = "correct"
        };

        var user = new User
        {
            UserId = 1,
            Username = "alice",
            IsApproved = true,
            PasswordHash = "hashed",
            Role = new Role
            {
                RoleName = "Manager"
            }
        };

        _userRepoMock.Setup(r => r.GetByUsernameAsync("alice"))
            .ReturnsAsync(user);

        _passwordServiceMock.Setup(p => p.VerifyPassword("correct", "hashed"))
            .Returns(true);

        _jwtTokenServiceMock.Setup(j => j.GenerateToken(
            1,
            "alice",
            "Manager"))
            .Returns("jwt_token");

        var result = await _sut.LoginAsync(dto);

        Assert.NotNull(result);
        Assert.Equal("jwt_token", result!.Token);
        Assert.Equal("alice", result.Username);
        Assert.Equal("Manager", result.Role);
    }

    [Fact]
    public async Task LoginAsync_WithValidCredentials_UpdatesLastLoginAt()
    {
        var dto = new LoginRequestDto
        {
            Username = "alice",
            Password = "correct"
        };

        var user = new User
        {
            UserId = 1,
            Username = "alice",
            IsApproved = true,
            PasswordHash = "hashed",
            Role = new Role
            {
                RoleName = "Manager"
            }
        };

        _userRepoMock.Setup(r => r.GetByUsernameAsync("alice"))
            .ReturnsAsync(user);

        _passwordServiceMock.Setup(p => p.VerifyPassword("correct", "hashed"))
            .Returns(true);

        _jwtTokenServiceMock.Setup(j => j.GenerateToken(
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<string>()))
            .Returns("token");

        var before = DateTime.UtcNow;

        await _sut.LoginAsync(dto);

        _userRepoMock.Verify(
            r => r.UpdateAsync(
                It.Is<User>(u => u.LastLoginAt >= before)),
            Times.Once);
    }
}