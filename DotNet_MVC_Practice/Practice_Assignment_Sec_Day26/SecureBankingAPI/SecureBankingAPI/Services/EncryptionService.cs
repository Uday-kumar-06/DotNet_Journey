using System.Security.Cryptography;
using System.Text;

namespace SecureBankingAPI.Services
{
    public class EncryptionService
    {
        private readonly string key =
            "12345678901234567890123456789012";

        public string Encrypt(string plainText)
        {
            using Aes aes = Aes.Create();

            aes.Key = Encoding.UTF8.GetBytes(key);

            aes.GenerateIV();

            var encryptor =
                aes.CreateEncryptor();

            byte[] encrypted =
                encryptor.TransformFinalBlock(
                Encoding.UTF8.GetBytes(plainText),
                0,
                Encoding.UTF8.GetBytes(plainText).Length);

            return
                Convert.ToBase64String(aes.IV)
                + ":"
                + Convert.ToBase64String(encrypted);
        }
    }
}