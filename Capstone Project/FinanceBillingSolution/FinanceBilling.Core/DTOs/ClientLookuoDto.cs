using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Core.DTOs
{
    public class ClientLookupDto
    {
        public int UserId { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
