using FinanceBilling.Core.DTOs;
using FinanceBilling.Core.Enums;
using FinanceBilling.Core.Interfaces.Repositories;
using FinanceBilling.Core.Interfaces.Services;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceBilling.Infrastructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IAuditLogRepository _auditLogRepository;

        public DashboardService(
            IInvoiceRepository invoiceRepository,
            IPaymentRepository paymentRepository,
            IAuditLogRepository auditLogRepository)
        {
            _invoiceRepository = invoiceRepository;
            _paymentRepository = paymentRepository;
            _auditLogRepository = auditLogRepository;
        }

        public async Task<DashboardSummaryDto> GetSummaryAsync()
        {
            var invoices =
                await _invoiceRepository.GetAllAsync();

            var payments =
                await _paymentRepository.GetAllAsync();

            var activities =
                await _auditLogRepository.GetAllAsync();

            var totalBilled =
                invoices.Sum(x => x.TotalAmount);

            var totalCollected =
                payments.Sum(x => x.AmountPaid);

            var outstandingAmount =
                totalBilled - totalCollected;

            var totalInvoices =
                invoices.Count();

            var paidInvoices =
                invoices.Count(x =>
                    x.Status == InvoiceStatus.Paid);

            var pendingInvoices =
                invoices.Count(x =>
                    x.Status == InvoiceStatus.Pending);

            var overdueInvoices =
                invoices.Count(x =>
                    x.Status == InvoiceStatus.Overdue);

            var latestActivities =
                activities
                    .OrderByDescending(x => x.ChangedAt)
                    .Take(5)
                    .Select(x =>
                        new RecentActivityDto
                        {
                            Username =
                                x.User?.Username ??
                                "System",

                            Action =
                                x.Action,

                            ChangedAt =
                                x.ChangedAt
                        })
                    .ToList();

            return new DashboardSummaryDto
            {
                TotalBilled = totalBilled,
                TotalCollected = totalCollected,
                OutstandingAmount = outstandingAmount,
                TotalInvoices = totalInvoices,

                PaidInvoices = paidInvoices,
                PendingInvoices = pendingInvoices,
                OverdueInvoices = overdueInvoices,

                RecentActivities = latestActivities
            };
        }
    }
}