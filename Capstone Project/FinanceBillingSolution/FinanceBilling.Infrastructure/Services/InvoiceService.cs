using FinanceBilling.Core.DTOs.Invoice;
using FinanceBilling.Core.Entities;
using FinanceBilling.Core.Enums;
using FinanceBilling.Core.Interfaces.Repositories;
using FinanceBilling.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Core.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IAuditLogRepository _auditRepository;

        public InvoiceService(
            IInvoiceRepository invoiceRepository,
            IAuditLogRepository auditRepository)
        {
            _invoiceRepository = invoiceRepository;
            _auditRepository = auditRepository;
        }

        public async Task CreateInvoiceAsync(
            int managerId,
            CreateInvoiceDto dto)
        {
            var invoice = new Invoice
            {
                ClientUserId = dto.ClientUserId,
                CreatedByManagerId = managerId,
                InvoiceDate = DateTime.UtcNow,
                DueDate = dto.DueDate,
                TotalAmount = dto.TotalAmount,
                Status = InvoiceStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _invoiceRepository.AddAsync(invoice);

            await _auditRepository.AddAsync(
                new AuditLog
                {
                    UserId = managerId,
                    Action = "Invoice Created",
                    EntityName = "Invoice",
                    EntityId = invoice.InvoiceId,
                    ChangedAt = DateTime.UtcNow,
                    Details =
                        $"Amount: {invoice.TotalAmount}"
                });
        }

        public async Task<IEnumerable<InvoiceDto>>
            GetAllAsync()
        {
            var invoices =
                await _invoiceRepository.GetAllAsync();

            return invoices.Select(x => new InvoiceDto
            {
                InvoiceId = x.InvoiceId,
                ClientUserId = x.ClientUserId,
                ClientName = x.ClientUser.Username,
                TotalAmount = x.TotalAmount,
                Status = x.Status.ToString(),
                InvoiceDate = x.InvoiceDate,
                DueDate = x.DueDate
            });
        }

        public async Task<IEnumerable<InvoiceDto>>
            GetClientInvoicesAsync(int clientId)
        {
            var invoices =
                await _invoiceRepository
                    .GetByClientIdAsync(clientId);

            return invoices.Select(x => new InvoiceDto
            {
                InvoiceId = x.InvoiceId,
                ClientUserId = x.ClientUserId,
                ClientName = x.ClientUser.Username,
                TotalAmount = x.TotalAmount,
                Status = x.Status.ToString(),
                InvoiceDate = x.InvoiceDate,
                DueDate = x.DueDate
            });
        }
    }
}