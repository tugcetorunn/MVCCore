namespace MVCCore15ManyToMany.ViewModels.Kitap
{
    public class KitapListeleVM
    {
        public int KitapId { get; set; }
        public string KitapAdi { get; set; }
        public string Onsoz { get; set; }
        public int SayfaSayisi { get; set; }
        public decimal Fiyat { get; set; }
        public IEnumerable<string> Yazarlar { get; set; }
    }
}
