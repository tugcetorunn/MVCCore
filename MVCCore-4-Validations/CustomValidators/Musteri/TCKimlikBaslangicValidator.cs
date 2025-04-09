using System.ComponentModel.DataAnnotations;

namespace MVCCore_4_Validations.CustomValidators.Musteri
{
    public class TCKimlikBaslangicValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string valueStr = value as string;
            if (!valueStr.StartsWith('0'))
            {
                return true;
            }

            return false;
        }

    }
}
