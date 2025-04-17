using MVCCore12GenericRepository.Data;
using MVCCore12GenericRepository.Models;

namespace MVCCore12GenericRepository.Repositories
{
    public class KategoriRepository : BaseRepository<Kategori>
    {
        public KategoriRepository(SahafDbContext _context) : base(_context)
        {
        }


    }
}
