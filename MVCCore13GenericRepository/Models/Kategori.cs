namespace MVCCore13GenericRepository.Models
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string KategoriAd { get; set; }
        public ICollection<Eylem>? Eylemler { get; set; }
    }
}
