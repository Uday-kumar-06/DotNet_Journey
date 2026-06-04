using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Core.DTOs
{
    public class DashboardSummaryDto
    {
        public decimal TotalBilled { get; set; }

        public decimal TotalCollected { get; set; }

        public decimal OutstandingAmount { get; set; }

        public int TotalInvoices { get; set; }

        public int PaidInvoices { get; set; }

        public int PendingInvoices { get; set; }

        public int OverdueInvoices { get; set; }

        public List<RecentActivityDto>
    RecentActivities
        { get; set; }
        = new();
    }
}
