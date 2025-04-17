using System;
using System.Collections.Generic;

namespace MVCCore12GenericRepository.Models;

public partial class Yayinevi
{
    public int YayineviId { get; set; }

    public string YayineviAdi { get; set; } = null!;

    public virtual ICollection<Kitap> Kitaplar { get; set; } = new List<Kitap>();
}
