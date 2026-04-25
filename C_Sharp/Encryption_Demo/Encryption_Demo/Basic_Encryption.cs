using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
namespace Encryption_Demo
{
    internal class Basic_Encryption
    {
        public void BasicEncrypt() {
            Console.WriteLine("Enter a string to encrypt: ");
            string str = Console.ReadLine();
            using(SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(str));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                Console.WriteLine(builder.ToString());
            }
        }


        public void BasicEncrypt(ref string str)
        {
           
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(str));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                str  = builder.ToString();
                //Console.WriteLine(builder.ToString());
            }
        }
    }
}
