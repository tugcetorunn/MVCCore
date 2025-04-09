using Microsoft.EntityFrameworkCore;

namespace MVCCore_5_Uygulama.Models.Extensions
{
    public static class DataExtension
    {
        public static void AddData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kategori>().HasData(KategoriEkle());
            modelBuilder.Entity<Yayinevi>().HasData(YayineviEkle());
            modelBuilder.Entity<Yazar>().HasData(YazarEkle());
        }

        public static List<Kategori> KategoriEkle()
        {
            List<Kategori> kategoriler = new List<Kategori>
            {
                new Kategori { KategoriId = 1, KategoriAdi = "Roman" },
                new Kategori { KategoriId = 2, KategoriAdi = "Bilim" },
                new Kategori { KategoriId = 3, KategoriAdi = "Tarih" },
                new Kategori { KategoriId = 4, KategoriAdi = "Edebiyat" },
                new Kategori { KategoriId = 5, KategoriAdi = "Kişisel Gelişim" }
            };
            return kategoriler;
        }

        public static List<Yayinevi> YayineviEkle()
        {
            List<Yayinevi> yayinevleri = new List<Yayinevi>
            {
                new Yayinevi { YayineviId = 1, YayineviAdi = "Can Yayınları" },
                new Yayinevi { YayineviId = 2, YayineviAdi = "Alfa Yayınları" },
                new Yayinevi { YayineviId = 3, YayineviAdi = "Pegasus Yayınları" }
            };
            return yayinevleri;
        }

        public static List<Yazar> YazarEkle()
        {
            List<Yazar> yazarlar = new List<Yazar>
            {
                new Yazar { YazarId = 1, YazarAdi = "Dan", YazarSoyadi = "Brown", Biyografi = "" },
                new Yazar { YazarId = 2, YazarAdi = "Adam", YazarSoyadi = "Fawer", Biyografi = "" },
                new Yazar { YazarId = 3, YazarAdi = "Michel", YazarSoyadi = "Montaigne", Biyografi = "" },
                new Yazar { YazarId = 4, YazarAdi = "Ömer", YazarSoyadi = "Seyfettin", Biyografi = "" },
                new Yazar { YazarId = 5, YazarAdi = "Halil", YazarSoyadi = "İnalcık", Biyografi = "" },
            };

            return yazarlar;
        }
    }
}
