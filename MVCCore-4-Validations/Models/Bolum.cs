namespace MVCCore_4_Validations.Models
{
    public class Bolum
    {
        public int BolumId { get; set; }
        public string BolumAdi { get; set; }
        public ICollection<Personel> Personeller { get; set; }
    }
}
