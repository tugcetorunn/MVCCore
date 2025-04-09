using MVCCore_5_Uygulama.Contexts;
using MVCCore_5_Uygulama.Models;
using MVCCore_5_Uygulama.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MVCCore_5_Uygulama.CustomValidators.Kitaplar
{
    public class BuKitapVarMiValid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            SahafDbContext context = (SahafDbContext)validationContext.GetService(typeof(SahafDbContext))!;
            KitapEkleVM kitap = (KitapEkleVM)validationContext.ObjectInstance;

            // Aynı kitap, aynı yazar, aynı basım ve aynı yayinevi mevcutsa false döndürür
            var kitapVarMi = context.Kitaplar.Any(x =>
                x.KitapAdi == kitap.KitapAdi && 
                x.YazarId == kitap.YazarId &&
                x.YayineviId == kitap.YayineviId &&
                x.BasimSayisi == kitap.BasimSayisi);

            if (kitapVarMi)
            {
                return new ValidationResult("Bu kitap zaten mevcut.");
            }

            return ValidationResult.Success;
        }
    }
}
