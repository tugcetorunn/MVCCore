﻿namespace MVCCore9ManuelIdentity.Models
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }
        public ICollection<Urun>? Urunler { get; set; }
    }
}
