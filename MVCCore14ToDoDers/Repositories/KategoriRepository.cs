using MVCCore14ToDoDers.Data;
using MVCCore14ToDoDers.Models;

namespace MVCCore14ToDoDers.Repositories
{
    public class KategoriRepository : BaseRepository<Kategori>
    {
        public KategoriRepository(ToDoDbContext _context) : base(_context)
        {
        }
    }
}
