namespace MVCCore15ManyToMany.ViewModels.Kitap
{
    public class KitapGuncelleVM
    {
        public int KitapId { get; set; }
        public string KitapAdi { get; set; }
        public string Onsoz { get; set; }
        public int SayfaSayisi { get; set; }
        public decimal Fiyat { get; set; }
        public IEnumerable<int> YazarIdler { get; set; }
    }
}
