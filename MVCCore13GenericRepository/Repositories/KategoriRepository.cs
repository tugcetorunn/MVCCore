using MVCCore13GenericRepository.Data;
using MVCCore13GenericRepository.Models;

namespace MVCCore13GenericRepository.Repositories
{
    public class KategoriRepository : BaseRepository<Kategori>
    {
        public KategoriRepository(ToDoDbContext _context) : base(_context)
        {
        }
    }
}
