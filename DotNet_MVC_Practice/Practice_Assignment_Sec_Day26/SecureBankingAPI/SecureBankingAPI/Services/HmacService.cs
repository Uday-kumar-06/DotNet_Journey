using System.Security.Cryptography;
using System.Text;

namespace SecureBankingAPI.Services
{
    public class HmacService
    {
        private readonly string secret =
            "MySecretKey123";

        public string GenerateHmac(string data)
        {
            using HMACSHA256 hmac =
                new HMACSHA256(
                    Encoding.UTF8.GetBytes(secret));

            byte[] hash =
                hmac.ComputeHash(
                    Encoding.UTF8.GetBytes(data));

            return Convert.ToBase64String(hash);
        }
    }
}