using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace OnlineBookStore.Validation
{
    public class IsbnValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            var isbn = value?.ToString();

            if (Regex.IsMatch(isbn, @"^\d{13}$"))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(
                "ISBN must contain exactly 13 digits");
        }
    }
}