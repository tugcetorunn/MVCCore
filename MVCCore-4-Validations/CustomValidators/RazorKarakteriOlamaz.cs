using System.ComponentModel.DataAnnotations;

namespace MVCCore_4_Validations.CustomValidators
{
    public class RazorKarakteriOlamaz : ValidationAttribute // @ işareti olamaz demek
    {
        public override bool IsValid(object? value)
        {
            if (value != null)
            {
                string deger = value as string;
                return !deger.Contains("@");
            }

            return true; // null ise geçerli kabul et
        }
    }
}
