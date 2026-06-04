using FinanceBilling.Core.DTOs.Payment;
using FinanceBilling.Core.Entities;
using FinanceBilling.Core.Enums;
using FinanceBilling.Core.Interfaces.Repositories;
using FinanceBilling.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceBilling.Core.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IAuditLogRepository _auditRepository;

        public PaymentService(
            IPaymentRepository paymentRepository,
            IInvoiceRepository invoiceRepository,
            IAuditLogRepository auditRepository)
        {
            _paymentRepository = paymentRepository;
            _invoiceRepository = invoiceRepository;
            _auditRepository = auditRepository;
        }

        public async Task AddPaymentAsync(int userId, CreatePaymentDto dto)
        {
            var payment = new Payment
            {
                InvoiceId = dto.InvoiceId,
                AmountPaid = dto.AmountPaid,
                PaymentDate = DateTime.UtcNow,
                PaymentMethod = dto.PaymentMethod
            };

            await _paymentRepository.AddAsync(payment);

            await _auditRepository.AddAsync(
                    new AuditLog
                    {
                        UserId = userId,
                        Action = "Payment Recorded",
                        EntityName = "Payment",
                        EntityId = payment.PaymentId,
                        ChangedAt = DateTime.UtcNow,
                        Details = $"InvoiceId: {payment.InvoiceId}"
                    });

            var invoice =
                await _invoiceRepository
                    .GetByIdAsync(dto.InvoiceId);

            if (invoice == null)
                throw new Exception("Invoice not found.");

            var payments =
                await _paymentRepository
                    .GetByInvoiceIdAsync(dto.InvoiceId);

            var totalPaid =
                payments.Sum(x => x.AmountPaid);

            if (totalPaid >= invoice.TotalAmount)
            {
                invoice.Status = InvoiceStatus.Paid;
            }
            else if (invoice.DueDate < DateTime.UtcNow)
            {
                invoice.Status = InvoiceStatus.Overdue;
            }
            else
            {
                invoice.Status = InvoiceStatus.Pending;
            }

            await _invoiceRepository.UpdateAsync(invoice);
        }

        public async Task<IEnumerable<PaymentDto>>
            GetInvoicePaymentsAsync(int invoiceId)
        {
            var payments =
                await _paymentRepository
                    .GetByInvoiceIdAsync(invoiceId);

            return payments.Select(x => new PaymentDto
            {
                PaymentId = x.PaymentId,
                InvoiceId = x.InvoiceId,
                AmountPaid = x.AmountPaid,
                PaymentDate = x.PaymentDate
            });
        }

        public async Task<IEnumerable<PaymentDto>> GetAllAsync()
        {
            var payments =
                await _paymentRepository.GetAllAsync();

            return payments.Select(x => new PaymentDto
            {
                PaymentId = x.PaymentId,
                InvoiceId = x.InvoiceId,
                AmountPaid = x.AmountPaid,
                PaymentDate = x.PaymentDate
            });
        }
    }
}