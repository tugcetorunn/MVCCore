using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore9ManuelIdentity.ViewModels.Ürünler
{
    public class UrunListeleVM
    {
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public decimal Fiyat { get; set; }
        public string ResimYolu { get; set; }
        public string Kategori { get; set; }
        public string EkleyenUye { get; set; }
    }
}
