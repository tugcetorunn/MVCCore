using System;
using System.Collections.Generic;

namespace MVCCore12GenericRepository.Models;

public partial class Kitap
{
    public int KitapId { get; set; }

    public string KitapAdi { get; set; } = null!;

    public decimal Fiyat { get; set; }

    public int SayfaSayisi { get; set; }

    public string KapakResmiUrl { get; set; } = null!;

    public string Ozet { get; set; } = null!;

    public int BasimSayisi { get; set; }

    public int YazarId { get; set; }

    public int YayineviId { get; set; }

    public int KategoriId { get; set; }

    public virtual Kategori Kategori { get; set; } = null!;

    public virtual Yayinevi Yayinevi { get; set; } = null!;

    public virtual Yazar Yazar { get; set; } = null!;
}
