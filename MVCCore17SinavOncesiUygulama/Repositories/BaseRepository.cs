using Microsoft.EntityFrameworkCore;
using MVCCore17SinavOncesiUygulama.Abstracts;
using MVCCore17SinavOncesiUygulama.Data;

namespace MVCCore17SinavOncesiUygulama.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly KitapDbContext context;
        protected DbSet<TEntity> table;
        public BaseRepository(KitapDbContext _context)
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
