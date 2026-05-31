using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace SecureBankingAPI.Services
{
    public class PasswordService
    {
        public string HashPassword(string password)
        {
            byte[] salt =
                RandomNumberGenerator.GetBytes(16);

            string hash =
                Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password,
                    salt,
                    KeyDerivationPrf.HMACSHA256,
                    100000,
                    32));

            return $"{Convert.ToBase64String(salt)}:{hash}";
        }
    }
}