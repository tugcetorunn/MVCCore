using System.Linq.Expressions;

namespace MVCCore12GenericRepository.Repositories
{
    public interface ICRUD<TEntity> where TEntity : class
    {
        TEntity Bul(int id, params Expression<Func<TEntity, object>>[] includes);
        TEntity Bul(int id);
        IEnumerable<TEntity> Listele();
        void Ekle(TEntity entity);
        void Guncelle(TEntity entity);
        void Sil(int id);
    }
}
