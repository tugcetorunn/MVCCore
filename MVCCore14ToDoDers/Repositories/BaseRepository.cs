using Microsoft.EntityFrameworkCore;
using MVCCore14ToDoDers.Abstracts;
using MVCCore14ToDoDers.Data;

namespace MVCCore14ToDoDers.Repositories
{
    public class BaseRepository<TEntity> : ICRUD<TEntity> where TEntity : class
    {
        protected readonly ToDoDbContext context;
        protected DbSet<TEntity> table;
        public BaseRepository(ToDoDbContext _context)
        {
            context = _context;
            table = context.Set<TEntity>();
        }
        public void Ekle(TEntity entity)
        {
            table.Add(entity);
            context.SaveChanges();
        }
        public void Guncelle(TEntity entity)
        {
            table.Update(entity);
            context.SaveChanges();
        }
        public void Sil(int id)
        {
            var entity = Bul(id);
            if (entity != null)
            {
                table.Remove(entity);
                context.SaveChanges();
            }
        }
        public TEntity Bul(int id)
        {
            return table.Find(id);
        }
        public List<TEntity> Listele()
        {
            return table.ToList();
        }
    }
}
