using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCCore_5_Uygulama.ViewModels
{
    public class KitapGuncelleFormVM
    {
        public KitapGuncelleVM Kitap { get; set; } // burada yazılan property adı guncelleme post metodunda gönderilecek parametredir bu yüzden denkleşmesi için parametre de aynı adda olmalı (büyük küçük harf önemsiz)
        public SelectList Yazarlar { get; set; }
        public SelectList Yayinevleri { get; set; }
        public SelectList Kategoriler { get; set; }
    }
}
