using MVCCore14ToDoDers.Data;
using MVCCore14ToDoDers.Models;
using MVCCore14ToDoDers.ViewModels.Eylemler;

namespace MVCCore14ToDoDers.Repositories
{
    public class EylemRepository : BaseRepository<Eylem>
    {
        public EylemRepository(ToDoDbContext _context) : base(_context)
        {
        }

        public List<EylemListeleVM>? Listele(string id)
        {
            return table.Select(x => new EylemListeleVM 
            {
                EylemId = x.EylemId,
                Aciklama = x.Aciklama,
                OlusturmaTarihi = x.OlusturmaTarihi,
                EylemTarihi = x.EylemTarihi,
                TamamlandiMi = (x.TamamlandiMi) ? "Evet" : "Hayır",
                KategoriAdi = x.Kategori.KategoriAdi,
                UserId = x.UserId,
                EylemAdi = x.EylemAdi
            })
                .Where(x => x.UserId == id)
                .ToList();
        }
    }
}
