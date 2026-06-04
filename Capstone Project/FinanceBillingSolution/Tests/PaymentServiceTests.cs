using FinanceBilling.Core.DTOs.Payment;
using FinanceBilling.Core.Entities;
using FinanceBilling.Core.Enums;
using FinanceBilling.Core.Interfaces.Repositories;
using FinanceBilling.Core.Services;
using Moq;

namespace FinanceBilling.Tests;

public class PaymentServiceTests
{
    private readonly Mock<IPaymentRepository> _paymentRepoMock;
    private readonly Mock<IInvoiceRepository> _invoiceRepoMock;
    private readonly Mock<IAuditLogRepository> _auditRepoMock;
    private readonly PaymentService _sut;

    public PaymentServiceTests()
    {
        _paymentRepoMock = new Mock<IPaymentRepository>();
        _invoiceRepoMock = new Mock<IInvoiceRepository>();
        _auditRepoMock = new Mock<IAuditLogRepository>();

        _sut = new PaymentService(
            _paymentRepoMock.Object,
            _invoiceRepoMock.Object,
            _auditRepoMock.Object);
    }

    [Fact]
    public async Task AddPaymentAsync_WhenInvoiceNotFound_ThrowsException()
    {
        var dto = new CreatePaymentDto
        {
            InvoiceId = 99,
            AmountPaid = 100m,
            PaymentMethod = "Cash"
        };

        _invoiceRepoMock
            .Setup(r => r.GetByIdAsync(99))
            .ReturnsAsync((Invoice?)null);

        _paymentRepoMock
            .Setup(r => r.GetByInvoiceIdAsync(99))
            .ReturnsAsync(new List<Payment>());

        await Assert.ThrowsAsync<Exception>(
            () => _sut.AddPaymentAsync(1, dto));
    }

    [Fact]
    public async Task AddPaymentAsync_WhenFullyPaid_SetsStatusToPaid()
    {
        var invoice = new Invoice
        {
            InvoiceId = 1,
            TotalAmount = 500m,
            Status = InvoiceStatus.Pending,
            DueDate = DateTime.UtcNow.AddDays(10)
        };

        var dto = new CreatePaymentDto
        {
            InvoiceId = 1,
            AmountPaid = 500m,
            PaymentMethod = "BankTransfer"
        };

        _invoiceRepoMock
            .Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(invoice);

        _paymentRepoMock
            .Setup(r => r.GetByInvoiceIdAsync(1))
            .ReturnsAsync(new List<Payment>
            {
                new Payment
                {
                    AmountPaid = 500m
                }
            });

        await _sut.AddPaymentAsync(
            userId: 2,
            dto);

        _invoiceRepoMock.Verify(
            r => r.UpdateAsync(
                It.Is<Invoice>(inv =>
                    inv.Status == InvoiceStatus.Paid)),
            Times.Once);
    }

    [Fact]
    public async Task AddPaymentAsync_WhenPartialAndNotOverdue_StatusStaysPending()
    {
        var invoice = new Invoice
        {
            InvoiceId = 2,
            TotalAmount = 1000m,
            Status = InvoiceStatus.Pending,
            DueDate = DateTime.UtcNow.AddDays(10)
        };

        var dto = new CreatePaymentDto
        {
            InvoiceId = 2,
            AmountPaid = 400m,
            PaymentMethod = "Card"
        };

        _invoiceRepoMock
            .Setup(r => r.GetByIdAsync(2))
            .ReturnsAsync(invoice);

        _paymentRepoMock
            .Setup(r => r.GetByInvoiceIdAsync(2))
            .ReturnsAsync(new List<Payment>
            {
                new Payment
                {
                    AmountPaid = 400m
                }
            });

        await _sut.AddPaymentAsync(
            userId: 3,
            dto);

        _invoiceRepoMock.Verify(
            r => r.UpdateAsync(
                It.Is<Invoice>(inv =>
                    inv.Status == InvoiceStatus.Pending)),
            Times.Once);
    }

    [Fact]
    public async Task AddPaymentAsync_WhenPartialAndPastDueDate_SetsStatusToOverdue()
    {
        var invoice = new Invoice
        {
            InvoiceId = 3,
            TotalAmount = 1000m,
            Status = InvoiceStatus.Pending,
            DueDate = DateTime.UtcNow.AddDays(-1)
        };

        var dto = new CreatePaymentDto
        {
            InvoiceId = 3,
            AmountPaid = 200m,
            PaymentMethod = "Cash"
        };

        _invoiceRepoMock
            .Setup(r => r.GetByIdAsync(3))
            .ReturnsAsync(invoice);

        _paymentRepoMock
            .Setup(r => r.GetByInvoiceIdAsync(3))
            .ReturnsAsync(new List<Payment>
            {
                new Payment
                {
                    AmountPaid = 200m
                }
            });

        await _sut.AddPaymentAsync(
            userId: 4,
            dto);

        _invoiceRepoMock.Verify(
            r => r.UpdateAsync(
                It.Is<Invoice>(inv =>
                    inv.Status == InvoiceStatus.Overdue)),
            Times.Once);
    }

    [Fact]
    public async Task AddPaymentAsync_CreatesAuditLog()
    {
        var invoice = new Invoice
        {
            InvoiceId = 5,
            TotalAmount = 300m,
            DueDate = DateTime.UtcNow.AddDays(5)
        };

        var dto = new CreatePaymentDto
        {
            InvoiceId = 5,
            AmountPaid = 300m,
            PaymentMethod = "Card"
        };

        _invoiceRepoMock
            .Setup(r => r.GetByIdAsync(5))
            .ReturnsAsync(invoice);

        _paymentRepoMock
            .Setup(r => r.GetByInvoiceIdAsync(5))
            .ReturnsAsync(new List<Payment>
            {
                new Payment
                {
                    AmountPaid = 300m
                }
            });

        await _sut.AddPaymentAsync(
            userId: 7,
            dto);

        _auditRepoMock.Verify(
            r => r.AddAsync(
                It.Is<AuditLog>(log =>
                    log.UserId == 7 &&
                    log.Action == "Payment Recorded" &&
                    log.EntityName == "Payment")),
            Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsMappedPaymentDtos()
    {
        var payments = new List<Payment>
        {
            new Payment
            {
                PaymentId = 1,
                InvoiceId = 10,
                AmountPaid = 100m,
                PaymentDate = DateTime.UtcNow
            },
            new Payment
            {
                PaymentId = 2,
                InvoiceId = 11,
                AmountPaid = 200m,
                PaymentDate = DateTime.UtcNow
            }
        };

        _paymentRepoMock
            .Setup(r => r.GetAllAsync())
            .ReturnsAsync(payments);

        var result =
            (await _sut.GetAllAsync())
            .ToList();

        Assert.Equal(2, result.Count);
        Assert.Equal(100m, result[0].AmountPaid);
        Assert.Equal(11, result[1].InvoiceId);
    }

    [Fact]
    public async Task GetInvoicePaymentsAsync_ReturnsPaymentsForGivenInvoice()
    {
        var payments = new List<Payment>
        {
            new Payment
            {
                PaymentId = 5,
                InvoiceId = 20,
                AmountPaid = 50m,
                PaymentDate = DateTime.UtcNow
            }
        };

        _paymentRepoMock
            .Setup(r => r.GetByInvoiceIdAsync(20))
            .ReturnsAsync(payments);

        var result =
            (await _sut.GetInvoicePaymentsAsync(20))
            .ToList();

        Assert.Single(result);
        Assert.Equal(20, result[0].InvoiceId);
        Assert.Equal(50m, result[0].AmountPaid);
    }
}