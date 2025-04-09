using MVCCore_5_Uygulama.CustomValidators.Kitaplar;
using System.ComponentModel.DataAnnotations;

namespace MVCCore_5_Uygulama.Models
{
    public class Kitap
    {
        public int KitapId { get; set; }
        [BuKitapVarMiValid]
        [Required(ErrorMessage = "Kitap adı boş geçilemez.")]
        [StringLength(100, ErrorMessage = "Kitap adı en fazla 100 karakter olabilir.")]
        public string KitapAdi { get; set; }
        [Required(ErrorMessage = "Fiyat boş geçilemez.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat 0'dan büyük olmalıdır.")]
        public decimal Fiyat { get; set; }
        [Required(ErrorMessage = "Sayfa sayısı boş geçilemez.")]
        [Range(1, int.MaxValue, ErrorMessage = "Sayfa sayısı 1'den büyük olmalıdır.")]
        public int SayfaSayisi { get; set; }
        [Required(ErrorMessage = "Kapak resmi boş geçilemez.")]
        public string KapakResmiUrl { get; set; }
        [Required(ErrorMessage = "Özet boş geçilemez.")]
        [StringLength(200, ErrorMessage = "Özet en fazla 200 karakter olabilir.")]
        public string Ozet { get; set; }
        [Required(ErrorMessage = "Basım sayısı boş geçilemez.")]
        [Range(1, int.MaxValue, ErrorMessage = "Basım sayısı 1'den büyük olmalıdır.")]
        public int BasimSayisi { get; set; }
        [Required(ErrorMessage = "Yazar boş geçilemez.")]
        public int YazarId { get; set; }
        public Yazar? Yazar { get; set; }
        [Required(ErrorMessage = "Yayınevi boş geçilemez.")]
        public int YayineviId { get; set; }
        public Yayinevi? Yayinevi { get; set; }
        [Required(ErrorMessage = "Kategori boş geçilemez.")]
        public int KategoriId { get; set; }
        public Kategori? Kategori { get; set; }
    }
}
