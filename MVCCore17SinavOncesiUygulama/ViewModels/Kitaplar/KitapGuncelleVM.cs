using MVCCore17SinavOncesiUygulama.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore17SinavOncesiUygulama.ViewModels.Kitaplar
{
    public class KitapGuncelleVM
    {
        public int KitapId { get; set; }
        public string KitapAdi { get; set; }
        [RegularExpression("[0-9]", ErrorMessage = "Fiyat bir sayı olmalıdır.")] // tamsayı bekler.  [0-9]+(.[0-9][0-9]) ondalıklı için ne yazılır???
        public decimal Fiyat { get; set; }
        public string Ozet { get; set; }
        public int SayfaSayisi { get; set; }
        public List<int>? KategoriIdler { get; set; }
    }
}