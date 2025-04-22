namespace MVCCore15ManyToMany.ViewModels.Kitap
{
    public class KitapEkleVM
    {
        public string KitapAdi { get; set; }
        public string Onsoz { get; set; }
        public int SayfaSayisi { get; set; }
        public decimal Fiyat { get; set; }
        public List<int> YazarIdler { get; set; }
    }
}