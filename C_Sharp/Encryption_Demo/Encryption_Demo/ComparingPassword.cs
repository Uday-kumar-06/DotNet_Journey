using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Encryption_Demo
{
    internal class ComparingPassword
    {
        public bool ComparePassword(string password, string encryptedPassword)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString() == encryptedPassword;
            }
        }
    }
}
