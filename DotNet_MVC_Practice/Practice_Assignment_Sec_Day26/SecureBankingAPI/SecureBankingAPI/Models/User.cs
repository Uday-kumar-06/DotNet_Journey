namespace SecureBankingAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public string CreditCardNumber { get; set; }

        public string HmacSignature { get; set; }
    }
}