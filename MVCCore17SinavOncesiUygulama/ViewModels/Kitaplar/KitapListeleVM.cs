using MVCCore17SinavOncesiUygulama.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore17SinavOncesiUygulama.ViewModels.Kitaplar
{
    public class KitapListeleVM
    {
        public int KitapId { get; set; }
        public string KitapAdi { get; set; }
        public decimal Fiyat { get; set; }
        public string Ozet { get; set; }
        public int SayfaSayisi { get; set; }
        public ICollection<KitapKategoriVM> Kategoriler { get; set; }
        public string UyeId { get; set; }
    }
}
