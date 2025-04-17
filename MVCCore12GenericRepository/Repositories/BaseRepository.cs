
using Microsoft.EntityFrameworkCore;
using MVCCore12GenericRepository.Data;
using System.Linq.Expressions;

namespace MVCCore12GenericRepository.Repositories
{
    public abstract class BaseRepository<TEntity> : ICRUD<TEntity> where TEntity : class
    {
        protected readonly SahafDbContext context;
        protected readonly DbSet<TEntity> table;
        public BaseRepository(SahafDbContext _context)
        {
            context = _context;
            table = context.Set<TEntity>();
        }
        public TEntity Bul(int id, params Expression<Func<TEntity, object>>[]? includes)
        {
            IQueryable<TEntity> query = table;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.FirstOrDefault(x => EF.Property<int>(x, "Id") == id);
        }
        public TEntity Bul(int id)
        {
            return table.Find(id);
        }

        public void Ekle(TEntity entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }

        public void Guncelle(TEntity entity)
        {
            table.Update(entity);
            context.SaveChanges();
        }

        public IEnumerable<TEntity> Listele()
        {
            return table.ToList();
        }

        public IEnumerable<TEntity> Listele(params Expression<Func<TEntity, object>>[]? includes)
        {
            IQueryable<TEntity> query = table;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query.ToList();
        }

        public void Sil(int id)
        {
            context.Remove(Bul(id));
            context.SaveChanges();
        }
    }
}
