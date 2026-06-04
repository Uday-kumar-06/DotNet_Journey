using FinanceBilling.Core.DTOs.Invoice;
using FinanceBilling.Core.Entities;
using FinanceBilling.Core.Enums;
using FinanceBilling.Core.Interfaces.Repositories;
using FinanceBilling.Core.Services;
using Moq;

namespace FinanceBilling.Tests;

public class InvoiceServiceTests
{
    private readonly Mock<IInvoiceRepository> _invoiceRepoMock;
    private readonly Mock<IAuditLogRepository> _auditRepoMock;
    private readonly InvoiceService _sut;

    public InvoiceServiceTests()
    {
        _invoiceRepoMock = new Mock<IInvoiceRepository>();
        _auditRepoMock = new Mock<IAuditLogRepository>();

        _sut = new InvoiceService(
            _invoiceRepoMock.Object,
            _auditRepoMock.Object);
    }

    [Fact]
    public async Task CreateInvoiceAsync_AddsInvoiceWithPendingStatus()
    {
        var dto = new CreateInvoiceDto
        {
            ClientUserId = 5,
            DueDate = DateTime.UtcNow.AddDays(30),
            TotalAmount = 1500m
        };

        await _sut.CreateInvoiceAsync(
            managerId: 2,
            dto);

        _invoiceRepoMock.Verify(
            r => r.AddAsync(It.Is<Invoice>(inv =>
                inv.ClientUserId == 5 &&
                inv.CreatedByManagerId == 2 &&
                inv.TotalAmount == 1500m &&
                inv.Status == InvoiceStatus.Pending)),
            Times.Once);
    }

    [Fact]
    public async Task CreateInvoiceAsync_CreatesAuditLog()
    {
        var dto = new CreateInvoiceDto
        {
            ClientUserId = 5,
            DueDate = DateTime.UtcNow.AddDays(10),
            TotalAmount = 200m
        };

        await _sut.CreateInvoiceAsync(
            managerId: 3,
            dto);

        _auditRepoMock.Verify(
            r => r.AddAsync(It.Is<AuditLog>(log =>
                log.UserId == 3 &&
                log.Action == "Invoice Created" &&
                log.EntityName == "Invoice")),
            Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsAllInvoicesAsDtos()
    {
        var invoices = new List<Invoice>
        {
            new Invoice
            {
                InvoiceId = 1,
                ClientUserId = 10,
                TotalAmount = 500m,
                Status = InvoiceStatus.Pending,
                InvoiceDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(15),
                ClientUser = new User
                {
                    Username = "clientA"
                }
            },
            new Invoice
            {
                InvoiceId = 2,
                ClientUserId = 11,
                TotalAmount = 800m,
                Status = InvoiceStatus.Paid,
                InvoiceDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(5),
                ClientUser = new User
                {
                    Username = "clientB"
                }
            }
        };

        _invoiceRepoMock
            .Setup(r => r.GetAllAsync())
            .ReturnsAsync(invoices);

        var result =
            (await _sut.GetAllAsync())
            .ToList();

        Assert.Equal(2, result.Count);
        Assert.Equal("clientA", result[0].ClientName);
        Assert.Equal("Paid", result[1].Status);
    }

    [Fact]
    public async Task GetAllAsync_WhenNoInvoices_ReturnsEmptyList()
    {
        _invoiceRepoMock
            .Setup(r => r.GetAllAsync())
            .ReturnsAsync(new List<Invoice>());

        var result =
            await _sut.GetAllAsync();

        Assert.Empty(result);
    }

    [Fact]
    public async Task GetClientInvoicesAsync_ReturnsOnlyThatClientsInvoices()
    {
        var invoice = new Invoice
        {
            InvoiceId = 7,
            ClientUserId = 42,
            TotalAmount = 300m,
            Status = InvoiceStatus.Overdue,
            InvoiceDate = DateTime.UtcNow,
            DueDate = DateTime.UtcNow.AddDays(-1),
            ClientUser = new User
            {
                Username = "overdueclient"
            }
        };

        _invoiceRepoMock
            .Setup(r => r.GetByClientIdAsync(42))
            .ReturnsAsync(new List<Invoice>
            {
                invoice
            });

        var result =
            (await _sut.GetClientInvoicesAsync(42))
            .ToList();

        Assert.Single(result);
        Assert.Equal(42, result[0].ClientUserId);
        Assert.Equal("Overdue", result[0].Status);
    }

    [Fact]
    public async Task GetClientInvoicesAsync_WhenNoInvoicesForClient_ReturnsEmptyList()
    {
        _invoiceRepoMock
            .Setup(r => r.GetByClientIdAsync(99))
            .ReturnsAsync(new List<Invoice>());

        var result =
            await _sut.GetClientInvoicesAsync(99);

        Assert.Empty(result);
    }
}