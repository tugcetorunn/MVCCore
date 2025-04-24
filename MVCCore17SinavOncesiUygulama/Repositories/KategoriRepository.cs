using MVCCore17SinavOncesiUygulama.Abstracts;
using MVCCore17SinavOncesiUygulama.Data;
using MVCCore17SinavOncesiUygulama.Models;

namespace MVCCore17SinavOncesiUygulama.Repositories
{
    public class KategoriRepository : BaseRepository<Kategori>, IKategoriRepository
    {
        public KategoriRepository(KitapDbContext _context) : base(_context)
        {
        }
    }
}
