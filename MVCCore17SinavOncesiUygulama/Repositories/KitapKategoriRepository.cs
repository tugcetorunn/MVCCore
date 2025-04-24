using MVCCore17SinavOncesiUygulama.Abstracts;
using MVCCore17SinavOncesiUygulama.Data;
using MVCCore17SinavOncesiUygulama.Models;

namespace MVCCore17SinavOncesiUygulama.Repositories
{
    public class KitapKategoriRepository : BaseRepository<KitapKategori>, IKitapKategoriRepository
    {
        public KitapKategoriRepository(KitapDbContext _context) : base(_context)
        {
        }
    }
}
