﻿using System;
using System.Collections.Generic;

namespace MVCCore_6_CookieSession.Models;

public partial class Kategoriler
{
    public int KategoriId { get; set; }

    public string KategoriAdi { get; set; } = null!;

    public virtual ICollection<Urunler> Urunlers { get; set; } = new List<Urunler>();
}
