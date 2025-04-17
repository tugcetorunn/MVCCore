using MVCCore12GenericRepository.Data;
using MVCCore12GenericRepository.Models;

namespace MVCCore12GenericRepository.Repositories
{
    public class YazarRepository : BaseRepository<Yazar>
    {
        public YazarRepository(SahafDbContext _context) : base(_context)
        {
        }
    }
}
