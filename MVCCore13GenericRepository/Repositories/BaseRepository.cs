
using Microsoft.EntityFrameworkCore;
using MVCCore13GenericRepository.Data;

namespace MVCCore13GenericRepository.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ToDoDbContext context;
        protected readonly DbSet<TEntity> table;
        public BaseRepository(ToDoDbContext _context)
        {
            context = _context;
            table = context.Set<TEntity>();
        }
        public TEntity Bul(int id)
        {
            return table.Find(id);
        }

        public bool Ekle(TEntity entity)
        {
            table.Add(entity);
            return context.SaveChanges() > 0 ? true : false;
        }

        public void Guncelle(TEntity entity)
        {
            table.Update(entity);
            context.SaveChanges();
        }

        public ICollection<TEntity> Listele()
        {
            return table.ToList();
        }

        public void Sil(int id)
        {
            table.Remove(Bul(id));
            context.SaveChanges();
        }
    }
}
