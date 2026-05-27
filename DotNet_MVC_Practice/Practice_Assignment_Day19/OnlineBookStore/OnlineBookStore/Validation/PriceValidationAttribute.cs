using System.ComponentModel.DataAnnotations;

namespace OnlineBookStore.Validation
{
    public class PriceValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
            object value,
            ValidationContext validationContext)
        {
            decimal price = (decimal)value;

            if (price > 0 && price < 10000)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(
                "Price must be between 1 and 10000");
        }
    }
}