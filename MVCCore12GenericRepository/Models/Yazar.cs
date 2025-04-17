using System;
using System.Collections.Generic;

namespace MVCCore12GenericRepository.Models;

public partial class Yazar
{
    public int YazarId { get; set; }

    public string YazarAdi { get; set; } = null!;

    public string YazarSoyadi { get; set; } = null!;

    public string Biyografi { get; set; } = null!;

    public string YazarAdSoyad => $"{YazarAdi} {YazarSoyadi}";

    public virtual ICollection<Kitap> Kitaplar { get; set; } = new List<Kitap>();
}
