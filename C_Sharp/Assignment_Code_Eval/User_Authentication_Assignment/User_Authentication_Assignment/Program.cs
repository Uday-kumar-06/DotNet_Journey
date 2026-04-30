using System.Security.Cryptography;
using System.Text;
using User_Authentication_Assignment.Encryption;
using User_Authentication_Assignment.UserAuthentication.model;

class Program
{
    public static void Main(string[] args)
    {
        UserCreation.UserCreating();

        AesEncryptionService aesService = new AesEncryptionService("mySecretKey123");
        Console.WriteLine("Enter text to encrypt:");
        string plainText = Console.ReadLine();
        string encrypted = aesService.Encrypt(plainText);
        Console.WriteLine($"\nEncrypted Text:\n{encrypted}");
        string decrypted = aesService.Decrypt(encrypted);
        Console.WriteLine($"\nDecrypted Text:\n{decrypted}");
    }
}