using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Core.Interfaces.Services
{
    public interface IJwtTokenService
    {
        string GenerateToken(
            int userId,
            string username,
            string role);
    }
}
