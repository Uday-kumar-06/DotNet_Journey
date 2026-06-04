using FinanceBilling.Core.DTOs.User;
using FinanceBilling.Core.Entities;
using FinanceBilling.Core.Interfaces.Repositories;
using FinanceBilling.Core.Services;
using Moq;

namespace FinanceBilling.Tests;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _userRepoMock;
    private readonly Mock<IAuditLogRepository> _auditRepoMock;
    private readonly UserService _sut;

    public UserServiceTests()
    {
        _userRepoMock = new Mock<IUserRepository>();
        _auditRepoMock = new Mock<IAuditLogRepository>();

        _sut = new UserService(
            _userRepoMock.Object,
            _auditRepoMock.Object);
    }

    [Fact]
    public async Task GetPendingUsersAsync_ReturnsMappedUserDtos()
    {
        var users = new List<User>
        {
            new User
            {
                UserId = 1,
                Username = "alice",
                Email = "alice@test.com",
                IsApproved = false
            },
            new User
            {
                UserId = 2,
                Username = "bob",
                Email = "bob@test.com",
                IsApproved = false
            }
        };

        _userRepoMock
            .Setup(r => r.GetPendingUsersAsync())
            .ReturnsAsync(users);

        var result =
            (await _sut.GetPendingUsersAsync())
            .ToList();

        Assert.Equal(2, result.Count);
        Assert.Equal("alice", result[0].Username);
        Assert.False(result[0].IsApproved);
    }

    [Fact]
    public async Task GetPendingUsersAsync_WhenNoPendingUsers_ReturnsEmptyList()
    {
        _userRepoMock
            .Setup(r => r.GetPendingUsersAsync())
            .ReturnsAsync(new List<User>());

        var result =
            await _sut.GetPendingUsersAsync();

        Assert.Empty(result);
    }

    [Fact]
    public async Task ApproveUserAsync_WhenUserNotFound_ThrowsException()
    {
        var dto = new ApproveUserDto
        {
            UserId = 99,
            RoleId = 2
        };

        _userRepoMock
            .Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((User?)null);

        var ex = await Assert.ThrowsAsync<Exception>(
            () => _sut.ApproveUserAsync(
                adminUserId: 1,
                dto));

        Assert.Equal(
            "User not found.",
            ex.Message);
    }

    [Fact]
    public async Task ApproveUserAsync_SetsIsApprovedAndRoleId()
    {
        var user = new User
        {
            UserId = 5,
            Username = "charlie",
            IsApproved = false
        };

        var dto = new ApproveUserDto
        {
            UserId = 5,
            RoleId = 3
        };

        _userRepoMock
            .Setup(r => r.GetByIdAsync(5))
            .ReturnsAsync(user);

        await _sut.ApproveUserAsync(
            adminUserId: 1,
            dto);

        _userRepoMock.Verify(
            r => r.UpdateAsync(It.Is<User>(u =>
                u.IsApproved &&
                u.RoleId == 3)),
            Times.Once);
    }

    [Fact]
    public async Task ApproveUserAsync_CreatesAuditLog()
    {
        var user = new User
        {
            UserId = 6,
            Username = "dave"
        };

        var dto = new ApproveUserDto
        {
            UserId = 6,
            RoleId = 2
        };

        _userRepoMock
            .Setup(r => r.GetByIdAsync(6))
            .ReturnsAsync(user);

        await _sut.ApproveUserAsync(
            adminUserId: 10,
            dto);

        _auditRepoMock.Verify(
            r => r.AddAsync(It.Is<AuditLog>(log =>
                log.UserId == 10 &&
                log.Action == "User Approved" &&
                log.EntityName == "User" &&
                log.EntityId == 6)),
            Times.Once);
    }

    [Fact]
    public async Task GetClientsAsync_ReturnsMappedClientLookupDtos()
    {
        var clients = new List<User>
        {
            new User
            {
                UserId = 20,
                Username = "client1",
                Email = "c1@test.com"
            },
            new User
            {
                UserId = 21,
                Username = "client2",
                Email = "c2@test.com"
            }
        };

        _userRepoMock
            .Setup(r => r.GetApprovedClientsAsync())
            .ReturnsAsync(clients);

        var result =
            (await _sut.GetClientsAsync())
            .ToList();

        Assert.Equal(2, result.Count);
        Assert.Equal("client1", result[0].Username);
        Assert.Equal("c2@test.com", result[1].Email);
    }

    [Fact]
    public async Task GetClientsAsync_WhenNoClients_ReturnsEmptyList()
    {
        _userRepoMock
            .Setup(r => r.GetApprovedClientsAsync())
            .ReturnsAsync(new List<User>());

        var result =
            await _sut.GetClientsAsync();

        Assert.Empty(result);
    }
}