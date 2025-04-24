namespace MVCCore17SinavOncesiUygulama.Abstracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Ekle(TEntity entity);
        void Guncelle(TEntity entity);
        void Sil(int id);
        TEntity Bul(int id);
        List<TEntity> Listele();
    }
}
