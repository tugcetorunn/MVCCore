using Microsoft.EntityFrameworkCore;
using MVCCore13GenericRepository.Data;
using MVCCore13GenericRepository.Models;

namespace MVCCore13GenericRepository.Repositories
{
    public class EylemRepository : BaseRepository<Eylem>
    {
        public EylemRepository(ToDoDbContext _context) : base(_context)
        {
        }

        public ICollection<Eylem> ListeleEager()
        {
            return table
                .Include(x => x.Kategori)
                .Include(x => x.Uye)
                .ToList();
        }

        public Eylem DetayEager(int id)
        {
            return table
                .Include(x => x.Kategori)
                .Include(x => x.Uye)
                .FirstOrDefault(x => x.EylemId == id);
        }

        //public Eylem EkleEager(Eylem eylem)
        //{
        //    table.Add(eylem);
        //    context.SaveChanges();
        //    return eylem;
        //}
    }
}
