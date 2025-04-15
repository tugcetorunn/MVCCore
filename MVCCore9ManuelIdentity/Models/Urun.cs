using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore9ManuelIdentity.Models
{
    // identity 1. adım gerekli paketlerin yüklenmesi:
    // Microsoft.AspNetCore.Identity.EntityFrameworkCore
    // Microsoft.AspNetCore.Identity.UI // adddefaultidentity metodu için
    // Microsoft.AspNetCore.EntityFrameworkCore
    // Microsoft.EntityFrameworkCore.SqlServer
    // Microsoft.EntityFrameworkCore.Tools
    // identity 2. adım modellerin oluşturulması
    public class Urun
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public string ResimYolu { get; set; }
        public int KategoriId { get; set; }
        [ForeignKey("Uye")]
        public int EkleyenUye { get; set; }
        public Kategori? Kategori { get; set; }
        public Uye? Uye { get; set; }
    }
}
