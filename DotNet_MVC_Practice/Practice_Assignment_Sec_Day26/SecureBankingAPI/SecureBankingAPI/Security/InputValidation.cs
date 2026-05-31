using System.Text.RegularExpressions;

namespace SecureBankingAPI.Security
{
    public static class InputValidation
    {
        public static bool IsSafe(string input)
        {
            string pattern =
                @"<script>|DROP|DELETE|INSERT|--";

            return !Regex.IsMatch(
                input,
                pattern,
                RegexOptions.IgnoreCase);
        }
    }
}