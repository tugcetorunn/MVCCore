using System.ComponentModel.DataAnnotations;

namespace MVCCore_4_Validations.CustomValidators.Musteri
{
    public class TCKimlikHaneValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string valueStr = value as string;
            if (valueStr.Length == 11)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("TC 11 haneden oluşmalıdır.");
        }

    }
}
