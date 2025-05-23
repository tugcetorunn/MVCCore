﻿using System.ComponentModel.DataAnnotations;

namespace MVCCore17SinavOncesiUygulama.ViewModels.Kitaplar
{
    /// <summary>
    /// kitap listelenirken kullanıcının göreceği ve view de kullanılacak olan propertyler
    /// </summary>
    public class KitapListeleVM
    {
        [Display(Name = "Kitap Id")]
        public int KitapId { get; set; }

        [Display(Name = "Kitap Adı")]
        public string KitapAdi { get; set; }
        public decimal Fiyat { get; set; }

        [Display(Name = "Sayfa Sayısı")]
        public int SayfaSayisi { get; set; }

        [Display(Name = "Ekleyen Üye")]
        public string UyeAd { get; set; }
        public string UyeId { get; set; }
    }
}
