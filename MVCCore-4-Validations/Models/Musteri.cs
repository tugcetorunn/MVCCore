using MVCCore_4_Validations.CustomValidators;
using MVCCore_4_Validations.CustomValidators.Musteri;

namespace MVCCore_4_Validations.Models
{
    public class Musteri
    {
        public int MusteriId { get; set; }
        [TCKimlikHaneValidator, TCKimlikBaslangicValidator, TCKimlikCiftValidator]
        public string TCKimlikNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
    }
}
