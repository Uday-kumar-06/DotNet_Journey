using FinanceBilling.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceBilling.Infrastructure.Security
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(
            string password,
            string hash)
        {
            return BCrypt.Net.BCrypt.Verify(
                password,
                hash);
        }
    }
}
