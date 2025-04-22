using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore14ToDoDers.ViewModels.Eylemler
{
    public class EylemListeleVM
    {
        public int EylemId { get; set; }
        public string EylemAdi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime EylemTarihi { get; set; }
        public string Aciklama { get; set; }
        public string TamamlandiMi { get; set; }
        public string KategoriAdi { get; set; }
        public string UserId { get; set; }
    }
}
