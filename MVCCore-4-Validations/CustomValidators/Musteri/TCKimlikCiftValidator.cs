using System.ComponentModel.DataAnnotations;

namespace MVCCore_4_Validations.CustomValidators.Musteri
{
    public class TCKimlikCiftValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            long valueInt = Convert.ToInt64(value.ToString());
            if (valueInt % 2 == 0)
            {
                return true;
            }

            return false;
        }

    }
}
