using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Core.DTOs
{
    public class RecentActivityDto
    {
        public string Username { get; set; }
            = string.Empty;

        public string Action { get; set; }
            = string.Empty;

        public DateTime ChangedAt { get; set; }
    }
}
