namespace MVCCore13GenericRepository.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool Ekle(TEntity entity);
        void Guncelle(TEntity entity);
        void Sil(int id);
        TEntity Bul(int id);
        ICollection<TEntity> Listele();
    }
}
